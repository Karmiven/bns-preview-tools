using System.IO;

using Xylia.Configure;
using Xylia.Extension;

namespace Xylia.Preview.Properties
{
	public static class CommonPath
	{
		/// <summary>
		/// 输出文件夹
		/// </summary>
		public static string OutputFolder
		{
			get => Ini.ReadValue("Folder", "Output");
			set
			{
				if (Directory.Exists(value))
					Ini.WriteValue("Folder", "Output", value);
			}
		}

		/// <summary>
		/// 游戏目录
		/// </summary>
		public static string GameFolder
		{
			get => Ini.ReadValue("Folder", "Game_Bns");
			set
			{
				if (Directory.Exists(value))
					Ini.WriteValue("Folder", "Game_Bns", value);
			}
		}




		/// <summary>
		/// 工作目录
		/// </summary>
		public static string WorkingDirectory { get; set; } = DataFiles;

		/// <summary>
		/// 数据文件文件夹
		/// </summary>
		public static string DataFiles => Ini.ReadValue("Folder", "PreviewFiles") ?? (OutputFolder + @"\data");

		public static bool DataLoadMode
		{
			get => Ini.ReadValue("Preview", "LoadMode").ToBoolOrNull() ?? true;
			set => Ini.WriteValue("Preview", "LoadMode", value);
		}

		public static int Test
		{
			get => Ini.ReadValue("Preview", "Test").ToInt();
			set => Ini.WriteValue("Preview", "Test", value);
		}
	}
}