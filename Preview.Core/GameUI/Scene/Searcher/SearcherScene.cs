using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.GameUI.Controls.List;

namespace Xylia.Preview.GameUI.Scene.Searcher
{
	public partial class SearcherScene : Form
	{
		public SearcherScene(IEnumerable<BaseRecord> Npcs)
		{
			InitializeComponent();


			var cells = new List<ListCell>();
			foreach (var npc in Npcs)
			{
				string NpcAlias = npc.alias;
				string NpcInfo = npc.Attributes["name2"].GetText() + $" ({ NpcAlias })";

				var StoreItemCell = new InfoListCell() { LeftText = NpcInfo };
				cells.Add(StoreItemCell);

				//查询地图信息
				var MapUnit = FileCache.Data.MapUnit.Where(Info => Info.alias.MyContains(NpcAlias)).FirstOrDefault();
				if (MapUnit != null)
				{
					StoreItemCell.ShowRightText = true;
					StoreItemCell.RightText = FileCache.Data.MapInfo[MapUnit.Mapid]?.Name2.GetText();
				}
			};

			this.storeListPreview1.Cells = cells;
		}
	

	    public static IEnumerable<BaseRecord> GetRelativeNpc(string StoreAlias)
		{
			return FileCache.Data.Npc.Where(npc =>
			   (FileCache.Data.Store2[npc.Store2_1]?.alias.MyEquals(StoreAlias) ?? false) ||
			   (FileCache.Data.Store2[npc.Store2_2]?.alias.MyEquals(StoreAlias) ?? false) ||
			   (FileCache.Data.Store2[npc.Store2_3]?.alias.MyEquals(StoreAlias) ?? false) ||
			   (FileCache.Data.Store2[npc.Store2_4]?.alias.MyEquals(StoreAlias) ?? false) ||
			   (FileCache.Data.Store2[npc.Store2_5]?.alias.MyEquals(StoreAlias) ?? false) ||
			   (FileCache.Data.Store2[npc.Store2_6]?.alias.MyEquals(StoreAlias) ?? false));
		}
	}
}