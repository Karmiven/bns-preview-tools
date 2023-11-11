﻿using System.Data;
using System.Diagnostics;
using System.Text;
using System.Xml;

using Newtonsoft.Json;

using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Common.Attribute;
using Xylia.Preview.Data.Common.DataStruct;
using Xylia.Preview.Data.Engine.BinData.Definitions;
using Xylia.Preview.Data.Engine.BinData.Helpers;
using Xylia.Preview.Data.Engine.Readers;
using Xylia.Preview.Data.Models;

namespace Xylia.Preview.Data.Engine.BinData.Models;

/// <summary>
/// bns data table
/// </summary>
[JsonConverter(typeof(TableConverter))]
public class Table : TableHeader, IDisposable
{
	#region Constructor
	/// <summary>
	/// table name
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// table owner
	/// </summary>
	public BnsDatabase Owner { get; set; }

	/// <summary>
	/// data struct definition
	/// </summary>
	public TableDefinition Definition { get; set; }


	/// <summary>
	/// path
	/// </summary>
	public string XmlPath { get; set; }
	#endregion

	#region Data
	internal TableArchive Archive { get; set; }

	/// <summary>
	/// TODO: Hack because the table seems to offset it randomly?
	/// </summary>
	public int RecordCountOffset { get; set; }

	/// <summary>
	/// TODO: Hack because idk where this padding is coming from
	/// </summary>
	public byte[] Padding { get; set; }


	internal Dictionary<Ref, Record> ByRef = new();

	internal Dictionary<AttributeDefinition, Dictionary<string, Record[]>> ByRequired = new();


	/// <summary>
	/// the table index
	/// should use hashmap
	/// </summary>
	/// <param name="attribute"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public Record[] Search(AttributeDefinition attribute, string value)
	{
		if (attribute != null && attribute.IsRequired)
		{
			lock (ByRequired)
			{
				// find group
				if (!ByRequired.TryGetValue(attribute, out var index))
				{
					var comparer = StringComparer.OrdinalIgnoreCase;
					index = _records
						.ToLookup(record => record.Attributes.Get(attribute.Name)?.ToString(), comparer)
						.Where(record => record.Key is not null)
						.ToDictionary(record => record.Key, record => record.ToArray(), comparer);

					ByRequired[attribute] = index;
				}

				// search item
				if (value != null && index.TryGetValue(value, out var result))
					return result;
			}
		}

		return Array.Empty<Record>();
	}



	protected List<Record> _records;

	/// <summary>
	/// element collection
	/// </summary>
	public List<Record> Records
	{
		internal set => _records = value;
		get
		{
			LoadAsync().Wait();
			return _records;
		}
	}
	#endregion


	#region Load Methods
	public virtual Task LoadAsync() => Task.Run(() =>
	{
		lock (this)
		{
			if (_records != null) return;

			if (XmlPath is null) LoadData();
			else
			{
				LoadXml(Owner.Provider.GetFiles(XmlPath).SelectMany(x =>
				{
					XmlDocument xml = new();
					xml.Load(x);
					x.Close();

					return xml.DocumentElement.SelectNodes($"./" + Definition.ElRecord.Name).OfType<XmlElement>();
				}).ToList());
			}
		}
	});


	private void LoadData()
	{
		Archive.ReadFrom(this);

		foreach (var record in _records)
		{
			record.Owner = this;
			record.Attributes = new(record);

			ByRef[record.Ref] = record;
		}
	}

	internal void LoadXml(IEnumerable<XmlElement> elements)
	{
		_records = new();
		foreach (var element in elements)
		{
			var record = new Record();
			record.Owner = this;
			record.Attributes = new(record, element, Definition.ElRecord);

			#region build ref
			record.Data = new byte[16];

			var type = record.Attributes["type"];
			record.SubclassType = type is null ? (short)-1 : (Definition.ElRecord.SubtableByName(type)?.SubclassType ?? 0);

			if (Definition.ElRecord.AutoKey) record.RecordId = _records.Count + 1;
			else
			{
				var builder = new RecordBuilder(null, null);
				record.ElDefinition.ExpandedAttributes
					.Where(attr => attr.IsKey)
					.ForEach(attr => builder.SetAttribute(record, attr, record.Attributes[attr.Name]));
			}
			#endregion

			ByRef[record.Ref] = record;
			_records.Add(record);
		}
	}
	#endregion

	#region Get Methods
	public Record this[string alias]
	{
		get
		{
			if (_records == null) LoadAsync().Wait();

			if (string.IsNullOrWhiteSpace(alias)) return null;

			var objs = Search(Definition.ElRecord["alias"], alias);
			if (objs.Length > 0) return objs.FirstOrDefault();
			else if (int.TryParse(alias, out var MainID)) return this[new Ref(MainID)];
			else if (alias.Contains('.'))
			{
				var o = alias.Split('.');
				if (o.Length == 2 && int.TryParse(o[0], out var id) && int.TryParse(o[1], out var variant))
					return this[new Ref(id, variant)];
			}

			if (_records.Any() && Name != "text")
				Debug.WriteLine($"[{Name}] get failed, alias: {alias}");
			return null;
		}
	}

	public Record this[Ref Ref, bool message = true]
	{
		get
		{
			if (Ref == default) return null;
			if (_records == null) LoadAsync().Wait();

			if (Ref.Id <= 0) return null;
			else if (ByRef.TryGetValue(Ref, out var item)) return item;
			else if (_records.Any() && message)
				Debug.WriteLine($"[{Name}] get failed, id: {Ref.Id} variation: {Ref.Variant}");

			return null;
		}
	}
	#endregion

	#region Serialize Methods
	public byte[] ToArray(bool is64Bit)
	{
		#region build
		//var builder = Owner.converter.Builder;
		//builder.InitializeTable(IsCompressed);

		//// Clear old records
		//base.Records.Clear();
		//foreach (var record in Records)
		//{
		//    record.Serialize(builder);
		//    base.Records.Add(record);
		//}

		//builder.FinalizeTable();
		#endregion


		//using var memoryStream = new MemoryStream();
		//using var writer = new BinaryWriter(memoryStream);

		//var bnsTableWriter = new TableWriter();
		//bnsTableWriter.WriteTo(writer, this, is64Bit);

		//return memoryStream.ToArray();

		return null;
	}


	public void WriteXml(string folder)
	{
		var path = folder + $"\\{Name.TitleCase()}Data.xml";

		Directory.CreateDirectory(Path.GetDirectoryName(path));
		File.WriteAllText(path, WriteXml());
	}

	public string WriteXml(params Record[] records)
	{
		var side = ReleaseSide.Client;

		using var ms = new MemoryStream();
		using var writer = XmlWriter.Create(ms, new XmlWriterSettings() { Indent = true, IndentChars = "\t" });

		writer.WriteStartDocument();
		writer.WriteStartElement(Definition.Els.FirstOrDefault().Name);
		writer.WriteAttributeString("release-module", Moudle.LocalizationData.ToString());
		writer.WriteAttributeString("release-side", side.ToString().ToLower());
		writer.WriteAttributeString("type", Definition.Name);
		writer.WriteAttributeString("version", MajorVersion + "." + MinorVersion);
		writer.WriteComment($" {Name}.xml ");

		foreach (var record in records.Any() ? records.ToList() : _records)
			record.WriteXml(writer, Definition.ElRecord);

		writer.WriteEndElement();
		writer.WriteEndDocument();
		writer.Flush();

		return Encoding.UTF8.GetString(ms.ToArray());
	}
	#endregion


	#region Interface
	public void Dispose()
	{
		_records?.ForEach(record => record.Dispose());
		_records = null;

		Definition = null;
		ByRef.Clear();
		ByRequired.Clear();

		GC.SuppressFinalize(this);
	}
	#endregion
}