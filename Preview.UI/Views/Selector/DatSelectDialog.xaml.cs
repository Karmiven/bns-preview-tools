﻿using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Xylia.Preview.Data.Engine.DatData;

namespace Xylia.Preview.UI.Views.Selector;
public partial class DatSelectDialog : Window, IDatSelect
{
	#region Constructor
	private IEnumerable<FileInfo>? list_xml;
	private IEnumerable<FileInfo>? list_local;

	public string? XML_Select;
	public string? Local_Select;

	private DatSelectDialog()
	{
		InitializeComponent();

		CountDown = new DispatcherTimer();
		CountDown.Interval = new TimeSpan(0, 0, 1);
		CountDown.Tick += CountDown_Tick;

		NoResponse = new DispatcherTimer();
		NoResponse.Interval = new TimeSpan(0, 0, 1);
		NoResponse.Tick += NoResponse_Tick;
	}
	#endregion

	#region Methods
	private void Window_MouseEnter(object sender, MouseEventArgs e)
	{
		StopCountDown();
		LastActTime = DateTime.Now;
	}

	private void Window_Loaded(object sender, RoutedEventArgs e)
	{
		RefreshList();
		StartCountDown();

		LastActTime = DateTime.Now;
		NoResponse.IsEnabled = true;
	}


	private void Btn_Confirm_Click(object sender, RoutedEventArgs e)
	{
		// stop timer
		NoResponse.Stop();
		CountDown.Stop();

		XML_Select = comboBox1.Text.Replace("...", @"contents\Local");
		Local_Select = comboBox2.Text.Replace("...", @"contents\Local");

		this.DialogResult = true;
		this.TimeInfo.Visibility = Visibility.Hidden;
	}

	private void Btn_Cancel_Click(object sender, EventArgs e)
	{
		this.DialogResult = false;
	}


	private void RefreshList()
	{
		Load_Cmb(comboBox1, list_xml);
		Load_Cmb(comboBox2, list_local);
	}

	private static void Load_Cmb(ComboBox control, IEnumerable<FileInfo> files)
	{
		control.Items.Clear();

		foreach (var f in files)
		{
			var s = f.FullName.Replace(@"contents\Local", "...");

			var is64 = Path.GetFileNameWithoutExtension(s).Contains("64");
			if (is64 && true) control.Items.Add(s);
		}

		control.Text = control.Items.Count == 0 ? null : control.Items[0].ToString();
		control.IsEnabled = control.Items.Count != 1;
	}
	#endregion

	#region CountDown
	private readonly DispatcherTimer CountDown;
	private readonly DispatcherTimer NoResponse;

	DateTime StartTime = DateTime.Now;
	DateTime LastActTime = DateTime.Now;

	const int CountDownSec = 10;
	const int NoResponseSec = 15;

	private void StartCountDown()
	{
		TimeInfo.Text = null;
		StartTime = DateTime.Now;

		this.CountDown.IsEnabled = true;
		this.TimeInfo.Visibility = Visibility.Visible;
	}

	private void StopCountDown()
	{
		this.CountDown.IsEnabled = false;
		this.TimeInfo.Visibility = Visibility.Hidden;
	}

	private void CountDown_Tick(object? sender, EventArgs e)
	{
		var RemainSec = CountDownSec - (int)DateTime.Now.Subtract(StartTime).TotalSeconds;
		TimeInfo.Text = StringHelper.Get("DatSelector_CountDown", RemainSec);

		if (RemainSec <= 0) Btn_Confirm_Click(null, null);
	}

	private void NoResponse_Tick(object? sender, EventArgs e)
	{
		var CurNoResponseSec = (int)DateTime.Now.Subtract(LastActTime).TotalSeconds;
		if (CurNoResponseSec >= NoResponseSec)
		{
			StartCountDown();
			LastActTime = DateTime.Now;
		}
	}
	#endregion


	#region IDatSelect
	DefaultProvider IDatSelect.Show(IEnumerable<FileInfo> Xml, IEnumerable<FileInfo> Local)
	{
		return Application.Current.Dispatcher.Invoke(() =>
		{
			var dialog = new DatSelectDialog()
			{
				list_xml = Xml,
				list_local = Local,
			};
			if (dialog.ShowDialog() != true) throw new OperationCanceledException();

			return new DefaultProvider(new FileInfo(dialog.XML_Select), new FileInfo(dialog.Local_Select));
		});
	}

	internal static DatSelectDialog Instance => Application.Current.Dispatcher.Invoke(() => new DatSelectDialog());
	#endregion
}