using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using BnsBinTool.Core.Definitions;

using Xylia.bns.Modules.DataFormat.Analyse;
using Xylia.Preview.Data.Helper;

namespace Xylia.Preview.Data.Definition
{
	public static class DefinitionHelper
	{
		public static List<MyTableDefinition> LoadTableDefinition()
		{
			#region 载入公共定义
			List<string> test = new();
			foreach (DictionaryEntry entry in Public.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true))
				test.Add(entry.Value as string);

			var PublicSeq = ConfigLoad.GetPublicSeq(test.ToArray());
			#endregion

			#region 载入表定义
			var TableInfo = new List<TableInfo>();
			foreach (DictionaryEntry entry in DataRes.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true))
			{
				try
				{
					string res = entry.Value as string;
					TableInfo.AddRange(ConfigLoad.Load(PublicSeq, res));
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(entry.Key + " -> " + ex.Message);
				}
			}
			#endregion

			return TableInfo.Select(table => MyTableDefinition.LoadFrom(table)).ToList();
		}

		public static List<MyTableDefinition> LoadTableDefinition(params string[] FilePathes)
		{
			#region 载入表定义
			var TableInfo = new List<TableInfo>();
			foreach (var f in FilePathes)
				TableInfo.AddRange(ConfigLoad.LoadFromFile(null, f));
			#endregion

			return TableInfo.Select(table => MyTableDefinition.LoadFrom(table)).ToList();
		}




		public static DatafileDefinition LoadDefinition(List<MyTableDefinition> tableDefinitions, DataTableSet set, bool mergeDuplicatedSequences = false, bool is64Bit = false)
		{
			foreach (var tableDef in tableDefinitions)
			{
				set.GetHelper(tableDef.Name).Definition = tableDef;
				if (tableDef.Type == 0) tableDef.Type = set.GetTableType(tableDef.TypeName);


				foreach (var attr in tableDef.ExpandedAttributes)
				{
					var referedTableName = ((MyAttributeDefinition)attr).ReferedTableName;
					if (referedTableName != null) attr.ReferedTable = set.GetTableType(referedTableName);
				}

				foreach (var subtable in tableDef.Subtables)
				{
					foreach (var attr in subtable.ExpandedAttributes)
					{
						var referedTableName = ((MyAttributeDefinition)attr).ReferedTableName;
						if (referedTableName != null) attr.ReferedTable = set.GetTableType(referedTableName);
					}
				}
			}


			var defs = tableDefinitions.DistinctBy(o => o.Type).Select(d => (TableDefinition)d).ToList();
			var datafileDeinition = new DatafileDefinition(defs) { Is64Bit = is64Bit };
			datafileDeinition.SequenceDefinitions.AddRange(new SequenceDefinitionLoader().LoadFor(defs, mergeDuplicatedSequences));
			return datafileDeinition;
		}
	}
}