﻿using System.IO;
using System.Windows;
using System.Xml;
using Xylia.Preview.Data.Engine.BinData.Helpers;
using Xylia.Preview.Data.Engine.BinData.Models;
using Xylia.Preview.Data.Engine.BinData.Serialization;
using Xylia.Preview.Data.Engine.DatData;
using Xylia.Preview.Data.Engine.Definitions;
using MessageBox = HandyControl.Controls.MessageBox;

namespace Xylia.Preview.UI.Helpers;
public class LocalProvider(string? Source) : DefaultProvider
{
	#region Properties
	/// <summary>
	/// Check source is dat file
	/// </summary>
	public bool CanSave { get; protected set; }

	public bool HaveBackup { get; protected set; }

	public Table TextTable => this.Tables["text"];
	#endregion

	#region Override Methods
	public override string Name => Path.GetFileName(Source);

	public override Stream[] GetFiles(string pattern) => [File.OpenRead(pattern)];

	public override void LoadData(DatafileDefinition definitions)
	{
		this.Tables = [];
		this.CanSave = this.HaveBackup = false;

		// invalid path
		if (string.IsNullOrWhiteSpace(Source)) return;

		var ext = Path.GetExtension(Source);
		switch (ext)
		{
			case ".xml" or ".x16":
			{
				var definition = definitions["text"];
				definition.Pattern = Source;

				Tables.Add(new Table() { Owner = this, Name = "text", Definition = definition });
				break;
			}

			case ".dat":
			{
				this.CanSave = true;

				LocalData = new FileInfo(Source);
				Is64Bit = LocalData.Bit64;
				ReadFrom(LocalData.SearchFiles(PATH.Localfile(Is64Bit)).FirstOrDefault()?.Data, Is64Bit);

				// detect text table type
				Detect = definitions.HasHeader ? new DatafileDirect(definitions.Header) : new DatafileDetect(this, definitions);
				Detect.ParseType(definitions);
				break;
			}
		}
	}
	#endregion

	#region Public Methods
	/// <summary>
	/// Replace existed text
	/// </summary>
	/// <param name="files">x16 file path</param>
	public void ReplaceText(FileInfo[] files)
	{
		var table = TextTable ?? throw new ArgumentException("bad table");

		foreach (var file in files)
		{
			XmlDocument xml = new() { PreserveWhitespace = true };
			xml.Load(file.FullName);

			foreach (XmlElement element in xml.DocumentElement!.SelectNodes($"./" + table.Definition.ElRecord.Name)!)
			{
				var alias = element.Attributes["alias"]?.Value;
				var text = element.InnerXml;

				var record = table[alias];
				if (record != null) record.Attributes["text"] = text;
			}
		}
	}

	/// <summary>
	/// Save as dat
	/// </summary>
	/// <remarks>
	/// <see langword="Source"/> must be a dat file
	/// </remarks>
	/// <param name="text"></param>
	public void Save(byte[] data)
	{
		var table = TextTable;
		ArgumentNullException.ThrowIfNull(table);

		using var stream = new MemoryStream(data);
		table.LoadXml(stream).ForEach(a => a.Invoke());

		WriteData(Source, new PublishSettings() { Is64bit = Is64Bit, Mode = Mode.Package });
	}

	public override void WriteData(string folder, PublishSettings settings)
	{
		var useBackup = !HaveBackup || MessageBox.Show(StringHelper.Get("TextView_BackUp_Ask"), StringHelper.Get("Message_Tip"), MessageBoxButton.YesNo) == MessageBoxResult.OK;
		var replaces = new Dictionary<string, byte[]>
		{
			{ PATH.Localfile(Is64Bit), WriteTo([.. Tables], settings.Is64bit) }
		};

		var param = new PackageParam(folder, settings.Is64bit);
		ThirdSupport.Pack(param, replaces, useBackup);

		HaveBackup = true;
	}
	#endregion
}