using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using HZH_Controls.Controls;

using Xylia.Preview.Common.Interface.RecordAttribute;

namespace Xylia.Preview.GameUI.Scene.Game_ToolTip.ItemTooltipPanel
{
	public partial class DataGridScene : Form
	{
		public DataGridScene(ParamTable ParamTable, AttributeCollection Attributes)
		{
			this.InitializeComponent();

			this.ucDataGridView1.Columns = new List<DataGridViewColumnEntity>
			{
				new() { DataField = "key", HeadText = "字段", Width = 40, WidthType = SizeType.Percent , Format = o => ParamTable.Convert(o) },
				new() { DataField = "value", HeadText = "数值", Width = 60, WidthType = SizeType.Percent },
			};


			DataTable dt = new();
			dt.Columns.Add("key");
			dt.Columns.Add("value");

			foreach(var a in Attributes)
			{
				DataRow dr = dt.NewRow();
				dr["key"] = a.Key;
				dr["value"] = a.Value;

				dt.Rows.Add(dr);
			}

			this.ucDataGridView1.DataSource = dt;
		}


		public class ParamTable
		{
			public Dictionary<string, string> ParamDef = new(StringComparer.InvariantCultureIgnoreCase);
			
			public string Convert(object ParamKey)
			{
				string ParamName = ParamKey.ToString();
				if (ParamDef != null && !string.IsNullOrWhiteSpace(ParamName))
				{
					if (ParamDef.TryGetValue(ParamName, out var Name))
						return Name;
				}

				return ParamName;
			}
		}
	}
}