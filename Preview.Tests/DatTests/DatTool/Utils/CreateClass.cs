﻿using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Engine.Definitions;

namespace Xylia.Preview.Tests.DatTests.DatTool.Utils;
public static class CreateClass
{
	public static string Instance(string text)
	{
		var xml = new XmlDocument();
		xml.LoadXml(text);

		return Instance(xml);
	}

	public static string Instance(XmlDocument xml)
	{
		StringBuilder result = new();

		var table = TableDefinitionHelper.LoadFrom(new SequenceDefinitionLoader(), xml.DocumentElement);
		var attributes = table.ElRecord.Attributes;
		foreach (var attribute in attributes) InstanceAttribute(attribute, result);

		foreach (var sub in table.ElRecord.Subtables)
		{
			result.AppendLine($"public sealed class {sub.Name.TitleCase()} : {table.Name.TitleCase()}");
			result.AppendLine("{");

			foreach (var attribute in sub.Attributes)
			{
				if (!attributes.Contains(attribute))
					InstanceAttribute(attribute, result, true);
			}

			result.Remove(result.Length - 1, 1);
			result.AppendLine("}\n");
		}

		return result.ToString();
	}


	private static void InstanceAttribute(AttributeDefinition attribute, StringBuilder result, bool SubClass = false)
	{
		var prefix = new string('\t', SubClass ? 1 : 0);

		#region type
		string TypeInfo = attribute.Type switch
		{
			AttributeType.TInt8 => "sbyte",
			AttributeType.TInt16 => "short",
			AttributeType.TInt32 => "int",
			AttributeType.TInt64 => "long",
			AttributeType.TFloat32 => "float",
			AttributeType.TBool => "bool",
			AttributeType.TString or AttributeType.TNative => "string",
			AttributeType.TRef => $"Ref<{attribute.ReferedTableName?.TitleCase()}>",
			AttributeType.TTRef => $"Ref<ModelElement>",
			AttributeType.TSub => $"Sub<{attribute.ReferedTableName?.TitleCase()}>",
			AttributeType.TSeq or AttributeType.TSeq16 or AttributeType.TProp_seq or AttributeType.TProp_field
				=> attribute.Sequence?.Name?.TitleCase() ?? attribute.Name.TitleCase() + "Seq",
			_ => attribute.Type.ToString().Remove(0, 1),
		};

		#endregion

		#region sys_attr
		List<string> sys_attr = [];
		if (new Regex(@"-\d").Match(attribute.Name).Success)
			sys_attr.Add($"Name(\"{attribute.Name}\")");

		if (attribute.Repeat > 1)
		{
			TypeInfo = $"{TypeInfo}[]";
		}

		if (sys_attr.Count != 0) result.AppendLine($"{prefix}[{string.Join(", ", sys_attr)}]");
		#endregion


		result.AppendLine($"{prefix}public {TypeInfo} {attribute.Name.TitleCase()} {{ get; set; }}\n");
	}
}