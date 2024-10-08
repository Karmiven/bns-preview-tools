﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xylia.Preview.Data.Models;

namespace Xylia.Preview.UI.Documents.Links;
public sealed class Tooltip : LinkId
{
	#region Methods
	internal override void Load(string text)
	{
		_popup = new ToolTip
		{
			Style = (Style)Application.Current.FindResource("BnsTooltip"),
			Content = text.GetText()
		};
	}

	internal override void OnMouseEnter(object sender, MouseEventArgs e)
	{
		_popup!.IsOpen = true;
	}

	internal override void OnMouseLeave(object sender, MouseEventArgs e)
	{
		_popup!.IsOpen = false;
	}
	#endregion

	#region Fields
	ToolTip? _popup;
	#endregion
}