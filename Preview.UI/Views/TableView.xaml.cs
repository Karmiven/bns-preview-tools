﻿using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using HandyControl.Data;
using Xylia.Preview.Data.Engine.BinData.Models;
using Xylia.Preview.Data.Models;
using Xylia.Preview.UI.Common.Converters;
using Xylia.Preview.UI.Common.Interactivity;

namespace Xylia.Preview.UI.Views;
public partial class TableView
{
	#region Constructorss
	public TableView()
	{
		InitializeComponent();

		ItemMenu = (ContextMenu)this.TryFindResource("ItemMenu");
		NameConverter = new RecordNameConverter();
	}
	#endregion

	#region Properties
	public Table Table
	{
		set
		{
			this.Title = string.Format("{0} {1}", StringHelper.Get("TableView_Name"), value.Name);
			this.ColumnList.ItemsSource = _source = CollectionViewSource.GetDefaultView(value.Records);

			CreateItemMenu(value.Name);
		}
	}
	#endregion

	#region Methods
	private void CreateItemMenu(string name)
	{
		ItemMenu.Items.Clear();

		RecordCommand.Find(name, (command) =>
		{
			var item = new MenuItem()
			{
				Header = StringHelper.Get(command.Name),
				Command = command,
			};
			item.SetBinding(MenuItem.CommandParameterProperty, new Binding("SelectedItem") { Source = ColumnList });

			ItemMenu.Items.Add(item);
		});
	}

	/// <summary>
	/// filter item
	/// </summary>	
	private bool Filter(object item, string rule)
	{
		if (item is Record record)
		{
			if (record.ToString().Contains(rule, StringComparison.OrdinalIgnoreCase)) return true;
			if (record.PrimaryKey.ToString().Contains(rule, StringComparison.OrdinalIgnoreCase)) return true;
			if (NameConverter.Convert(record).Contains(rule, StringComparison.OrdinalIgnoreCase)) return true;
		}

		return false;
	}

	/// <summary>
	/// search item
	/// </summary>
	private void SearchStarted(object sender, FunctionEventArgs<string> e)
	{
		_source.Filter = (o) => Filter(o, e.Info);
		_source.Refresh();
		_source.MoveCurrentToFirst();

		ColumnList.ScrollIntoView(_source.CurrentItem);
	}
	#endregion


	#region Data
	private readonly ContextMenu ItemMenu;
	private readonly RecordNameConverter NameConverter;
	private ICollectionView? _source;
	#endregion
}