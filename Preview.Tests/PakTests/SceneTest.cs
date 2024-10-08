﻿using System.IO;
using System.Xml.Linq;
using CUE4Parse.BNS;
using CUE4Parse.BNS.Assets.Exports;
using CUE4Parse.BNS.Conversion;
using CUE4Parse.UE4.Assets.Exports;
using CUE4Parse.UE4.Objects.Engine;
using CUE4Parse.UE4.Objects.UObject;
using CUE4Parse.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Helpers;
using Xylia.Preview.Tests.Extensions;

namespace Xylia.Preview.Tests.PakTests;

[TestClass]
public class SceneTest
{
	[TestMethod]
	public void SceneInformation()
	{
		var Output = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "scene");

		using GameFileProvider Provider = new(IniHelper.Instance.GameFolder);
		// using GameFileProvider Provider = new("D:\\WeGameApps\\剑灵\\剑灵\\BNSR\\Content\\Paks");
		//var AssetPath = "BNSR/Content/Art/UI/V2/Common/ContentsWidget/Item/LegacyItemTooltipWidget.uasset";
		var AssetPath = "BNSR/Content/Art/UI/GameUI/Scene/Game_Tooltip2/Game_TooltipScene2/GlyphSlotOpenTooltipPanel.uasset";
		var Blueprint = Provider.LoadAllObjects(AssetPath).OfType<UWidgetBlueprintGeneratedClass>().First();

		var dump = new WidgetDump() { Output = Path.Combine(Output, Path.GetFileNameWithoutExtension(AssetPath)) };
		dump.LoadBlueprint(Blueprint);
		

		#region Output
		var FirstNode = (XElement)dump.Root.FirstNode;
		FirstNode.Attribute("Name").Value = "#TEMP#";

		// get class name
		var FullClassName = $"Xylia.Preview.UI" + AssetPath.SubstringBeforeLast(".")
			.Replace("BNSR/Content/Art/UI", null)
			//.Replace("bnsr/content/art/ui/v3", "GameUI")
			.Replace("/", ".");

		var ClassName = FullClassName.SubstringAfterLast(".");
		FullClassName = FullClassName.SubstringBeforeLast(".").SubstringBeforeWithLast('.') + ClassName;

		Console.WriteLine(FirstNode.ToString().Replace(" Name=\"#TEMP#\"",
			$"""
				x:Class="{FullClassName}"
				xmlns="https://github.com/xyliaup/bns-preview-tools"
				xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
				xmlns:s="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
			"""));
		#endregion
	}
}

public class WidgetDump
{
	public string Output { get; set; }

	public bool ExtractImage = false;

	public XElement Root = new("temp");


	public void LoadBlueprint(UWidgetBlueprintGeneratedClass blueprint, int level = 0, XElement parent = null)
	{
		var bAllowTemplate = blueprint.GetOrDefault<bool>("bAllowTemplate");
		var bValidTemplate = blueprint.GetOrDefault<bool>("bValidTemplate");
		var bClassRequiresNativeTick = blueprint.GetOrDefault<bool>("bClassRequiresNativeTick");
		var DefaultObject = blueprint.ClassDefaultObject;
		var TemplateAsset = blueprint.GetOrDefault<FSoftObjectPath>("TemplateAsset");
		var WidgetTree = blueprint.GetOrDefault<UWidgetTree>("WidgetTree");
		//WidgetTree = TemplateAsset.Load().GetOrDefault<UWidgetTree>("WidgetTree");
		this.LoadWidget(WidgetTree.RootWidget.Load(), null, level, Root);

		// load widget which not on visual tree
		if (blueprint.Name.StartsWith("Legacy", StringComparison.OrdinalIgnoreCase))
		{
			parent ??= (XElement)Root.FirstNode;
			foreach (var widget in blueprint.Owner.GetExports().Where(x => x.Outer == WidgetTree))
			{
				// Console.WriteLine(JsonConvert.SerializeObject(widget, Formatting.Indented));
				LoadWidget(widget, null, level, parent);
			}
		}
	}

	public void LoadWidget(UObject obj, UBnsCustomBaseWidgetSlot widgetslot, int level, XElement parent)
	{
		if (obj.Template != null)
		{
			LoadBlueprint(obj.Template.Class.Load<UWidgetBlueprintGeneratedClass>(), level, parent);
			return;
		}

		var el = new XElement(obj.ExportType);
		el.Add(new XAttribute("Name", obj.Name));
		parent.Add(el);

		if (widgetslot != null)
		{
			el.AddAttribute("LayoutData.Anchors", widgetslot.LayoutData.Anchors);
			el.AddAttribute("LayoutData.Offsets", widgetslot.LayoutData.Offsets);
			el.AddAttribute("LayoutData.Alignments", widgetslot.LayoutData.Alignments);
		}

		if (obj is UBnsCustomBaseWidget widget)
		{
			el.AddAttribute("MetaData", widget.MetaData);

			if (widget.HorizontalResizeLink != null) el.AddElement($"{el.Name}.HorizontalResizeLink").AddElement("ResizeLink").Write(widget.HorizontalResizeLink);
			if (widget.VerticalResizeLink != null) el.AddElement($"{el.Name}.VerticalResizeLink").AddElement("ResizeLink").Write(widget.VerticalResizeLink);
			if (widget.StringProperty != null) el.AddElement($"{el.Name}.String").AddElement("StringProperty").Write(widget.StringProperty);
			if (widget.BaseImageProperty != null) el.AddElement($"{el.Name}.BaseImageProperty").AddElement("ImageProperty").Write(widget.BaseImageProperty);


			if (widget is UBnsCustomLabelButtonWidget buttonWidget)
			{
				el.AddElement($"{el.Name}.NormalImageProperty").AddElement("ImageProperty").Write(buttonWidget.NormalImageProperty);
				//Write(el, buttonWidget.ActivatedImageProperty);
			}

			Write(el, widget.ExpansionComponentList);

			if (ExtractImage)
			{
				Directory.CreateDirectory(Output);
				widget.BaseImageProperty.Image?.Save(Output + $"/{obj.Name}.png");
				widget.ExpansionComponentList?.ForEach(expansion => expansion.ImageProperty.Image?.Save(Output + $"/{obj.Name}.{expansion.ExpansionName}.png"));
			}
		}


		// children
		var Slots = obj.GetOrDefault<UBnsCustomBaseWidgetSlot[]>("Slots");
		Slots?.Where(slot => slot != null).Reverse()
			.ForEach(slot => LoadWidget(slot.Content.Load(), slot, level, el));
	}


	private static void WriteLine(int level, string message)
	{
		if (message is null) return;

		Console.WriteLine(new string('\t', level) + message);
	}

	private static void Write(XElement el, ExpansionComponent[] expansions)
	{
		if (expansions is null) return;

		var element = el.AddElement($"{el.Name}.ExpansionComponentList");
		expansions.ForEach(e => element.AddElement("ExpansionComponent").Write(e));
	}
}