using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.GameUI.Controls.List;

using static Xylia.Preview.Data.Record.Item;

namespace Xylia.Preview.GameUI.Scene.Game_Auction
{
	public partial class Game_AuctionScene : Form // PreviewFrm
	{
		#region 构造
		public Game_AuctionScene()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;

			#region Category
			var child = ChildCategory();

			TreeView.Nodes.Add("all", "UI.Market.Category.All".GetText());
			TreeView.Nodes.Add("favorites", "UI.Market.Category.Favorites".GetText());

			foreach (var category2 in Enum.GetValues<MarketCategory2Seq>())
			{
				if (category2 == MarketCategory2Seq.None) continue;

				var node = TreeView.Nodes.Add(category2.ToString(), $"Name.item.game-category-2.{category2.GetSignal()}".GetText());

				if (!child.TryGetValue(category2, out var category3Seqs)) continue;
				category3Seqs.ForEach(category3 => node.Nodes.Add(category3.ToString(), $"Name.item.game-category-3.{category3.GetSignal()}".GetText(true)));
			}
			#endregion

			FileCache.Data.Item.TryLoad();
			FileCache.PakData.Initialize();
		}

		public Game_AuctionScene(string rule) : this()
		{
			ItemPreview_Search.InputText = rule;
			TreeView.SelectedNode = TreeView.Nodes[0];
		}


		private static Dictionary<MarketCategory2Seq, List<MarketCategory3Seq>> ChildCategory()
		{
			var data = new Dictionary<MarketCategory2Seq, List<MarketCategory3Seq>>();
			Enum.GetValues<MarketCategory2Seq>().ForEach(seq => data[seq] = new());

			#region Weapon
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.Sword);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.Gauntlet);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.Axe);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.Staff);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.AuraBangle);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.Dagger);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.LynSword);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.WarlockDagger);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.SoulFighterGauntlet);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.Gun);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.LongBow);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.GreatSword);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.Orb);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.DualBlade);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.Instrument);
			data[MarketCategory2Seq.Weapon].Add(MarketCategory3Seq.Spear);
			#endregion

			#region	EquipGem
			data[MarketCategory2Seq.EquipGem].Add(MarketCategory3Seq.Gam1);
			data[MarketCategory2Seq.EquipGem].Add(MarketCategory3Seq.Gan2);
			data[MarketCategory2Seq.EquipGem].Add(MarketCategory3Seq.Jin3);
			data[MarketCategory2Seq.EquipGem].Add(MarketCategory3Seq.Son4);
			data[MarketCategory2Seq.EquipGem].Add(MarketCategory3Seq.Ri5);
			data[MarketCategory2Seq.EquipGem].Add(MarketCategory3Seq.Gon6);
			data[MarketCategory2Seq.EquipGem].Add(MarketCategory3Seq.Tae7);
			data[MarketCategory2Seq.EquipGem].Add(MarketCategory3Seq.Geon8);
			#endregion															

			#region	Accessory

			#endregion




			return data;
		}
		#endregion


		//Ini.ReadValue("Preview", "item#search_autoclose").ToBool();
		//Ini.ReadValue("Preview", "item#search_showextra").ToBool()

		private void LoadData(object sender, EventArgs e)
		{
			this.ItemList.Cells = null;

			var node = TreeView.SelectedNode;
			if (node.Name == "favorites") return;

			#region 初始化规则
			string rule = ItemPreview_Search.InputText;
			bool empty = string.IsNullOrWhiteSpace(rule);

			var IsAll = node.Name == "all";
			if (IsAll && empty) return;

			var category2 = IsAll ? default : (node.Level == 0 ? node : node.Parent).Name.ToEnum<MarketCategory2Seq>();
			var category3 = node.Level == 0 ? default : node.Name.ToEnum<MarketCategory3Seq>();

			var auctionable = Chk_Auctionable.Checked;
			#endregion



			new Thread(t =>
			{
				BlockingCollection<Item> lst = new();
				Parallel.ForEach(FileCache.Data.Item, o =>
				{
					if (!IsAll)
					{
						if (category2 != default && category2 != o.MarketCategory2) return;
						if (category3 != default && category3 != o.MarketCategory3) return;
					}


					if (!empty)
					{
						string ItemName = o.Name2;
						if (ItemName is null || ItemName.IndexOf(rule, StringComparison.OrdinalIgnoreCase) < 0) return;
					}

					if (auctionable && !o.Auctionable && !o.SealRenewalAuctionable) return;


					lst.Add(o);
				});


				IEnumerable<Item> temp;
				if (checkBox1.Checked) temp = lst.OrderByDescending(o => o.Key());
				else temp = lst.OrderBy(o => o.Key());
				this.ItemList.Invoke(() => this.ItemList.Cells = temp.Select(o => new ItemData(o)));
			}).Start();
		}
	}
}