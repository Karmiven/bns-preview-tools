using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Xylia.Configure;
using Xylia.Extension;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Record;
using Xylia.Preview.GameUI.Controls.List;
using Xylia.Preview.GameUI.Scene.Searcher;

using NpcData = Xylia.Preview.Data.Record.Npc;

namespace Xylia.Preview.GameUI.Scene.Game_ItemStore
{
	/// <summary>
	/// 商店预览
	/// </summary>
	public sealed partial class Game_ItemStoreScene : StoreScene
	{
		#region 构造
		public Dictionary<Store2Type, TreeNode> Nodes = new();

		public Game_ItemStoreScene() : base()
		{
			this.InitializeComponent();

			#region 设置商店分组
			this.TreeView.Nodes.Clear();

			Nodes.Add(Store2Type.UnlocatedStore, this.TreeView.Nodes.Add("飞龙工商"));
			Nodes.Add(Store2Type.AccountStore, this.TreeView.Nodes.Add("侠义团商店"));
			Nodes.Add(Store2Type.SoulBoostStore, this.TreeView.Nodes.Add("成长加速礼商店"));
			Nodes.Add(Store2Type.Normal, this.TreeView.Nodes.Add("普通商店"));
			#endregion

			#region 获取职业信息
			var Source = Job.GetPcJobName();
			Source.Insert(0, "全部");
			this.JobSelector.Source = Source; 

			var LastJobSelect = Ini.ReadValue("Preview", "JobFilter");
			this.JobSelector.TextValue = Source.Contains(LastJobSelect) ? LastJobSelect : this.JobSelector.Source.FirstOrDefault();
			#endregion


			#region 设置筛选内容
			this.Filter.Add(new FilterInfo(FilterTag.Text, "商店名", true));
			this.Filter.Add(new FilterInfo(FilterTag.Item, "出售物品", true));
			#endregion
		}
		#endregion

		#region 处理方法
		protected override void LoadData()
		{
			#region UnlocatedStore
			Dictionary<Store2, UnlocatedStore> UnlocatedStores = new();
			foreach (var o in FileCache.Data.UnlocatedStore)
			{
				var store = FileCache.Data.Store2[o.Store2];
				if (store is null) continue;

				UnlocatedStores[store] = o;
			}
			#endregion


			#region 读取数据
			var StoreInfoList = new List<StoreInfo>();
			foreach(var Store2 in FileCache.Data.Store2)
			{
				#region 初始化
				var Store2Alias = Store2.alias;
				string Name2 = Store2.Name2.GetText();
				string CurName = Name2 is null ? Store2Alias : $"[{ Name2 }] " + Store2Alias;


				int? Order = null;

				//远程商店设定
				var StoreType = Store2Type.Normal;
				if (UnlocatedStores.TryGetValue(Store2, out var UnlocatedStore))
				{
					#region 判断商店类型
					if (UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.AccountStore) StoreType = Store2Type.AccountStore;

					else if (
					UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.SoulBoostStore1 ||
					UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.SoulBoostStore2 ||
					UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.SoulBoostStore3 ||
					UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.SoulBoostStore4 ||
					UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.SoulBoostStore5 ||
					UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.SoulBoostStore6) StoreType = Store2Type.SoulBoostStore;

					else StoreType = Store2Type.UnlocatedStore;
					#endregion

					//读取顺序编号
					Order = UnlocatedStore.Key();
				}
				#endregion

				#region 生成控件
				StoreInfoList.Add(new StoreInfo()
				{
					Alias = Store2Alias,
					Name = CurName,

					//节点顺序
					Order = Order ?? Store2.Key(),
					StoreType = StoreType,
				});
				#endregion
			}
			#endregion

			#region 插入节点
			foreach (var Info in StoreInfoList.OrderBy(a => a.Order))
			{
				if (Nodes.ContainsKey(Info.StoreType))
				{
					var CurNode = Nodes[Info.StoreType].Nodes.Add(Info.Name);
					this.TreeNodeInfo.Add(CurNode, new NodeInfo(Info.Alias, CurNode));
				}
				//不显示SoulBoost商店
				else if (Info.StoreType != Store2Type.SoulBoostStore)
				{
					Console.WriteLine("不支持的商店类型：" + Info.StoreType);
				}
			}
			#endregion

			TreeView.Nodes[0].ExpandAll();
		}

		protected override void ShowStoreContent(string StoreAlias)
		{
			#region 初始化数据
			var Store2 = FileCache.Data.Store2[StoreAlias];
			if (Store2 is null) return;

			//获取当前选择的职业
			JobSeq SelectedJob = Job.GetJob(this.JobSelector.TextValue);

			this.Text = $"商店 { Store2.GetName() } ，加载数据中...";
			this.ListPreview.Name = Store2.alias;
			#endregion

			#region 读取数据
			var Cells = new List<ListCell>();
			for (int i = 1; i <= 127; i++)
			{
				string ItemAlias = Store2.Attributes["item-" + i];
				string BuyPrice = Store2.Attributes["buy-price-" + i];

				//获取物品信息
				var ItemInfo = FileCache.Data.Item[ItemAlias];
				if (ItemInfo is null) continue;

				if (!ItemInfo.CheckEquipJob(SelectedJob)) continue;

				var ItemBuyPrice = FileCache.Data.ItemBuyPrice[BuyPrice];
				this.ListPreview.Invoke(() => Cells.Add(new Store2ItemCell(ItemInfo, ItemBuyPrice)));  
			}

			this.Text = $"商店 { Store2.GetName() } ，共计 { Cells.Count }个兑换内容";
			this.ListPreview.Invoke(() => this.ListPreview.Cells = Cells);
			#endregion


			//获取是否存在出售NPC
			this.npcs = SearcherScene.GetRelativeNpc(StoreAlias);
			this.Invoke(() =>
			{
				this.ucBtnExt1.Visible = npcs != null && npcs.Any();
				Clipboard.SetText(Store2.alias);
			});
		}

		protected override bool FilterNode(NodeInfo NodeInfo, object FilterRule)
		{
			//如果搜索条件是物品信息，那么再搜索可购买物品
			if (FilterRule is Item FilterItem)
			{
				var Store2 = FileCache.Data.Store2[NodeInfo.AliasText];
				if (Store2 is null) return false;

				//遍历可购买物品字段
				foreach (var a in Store2.Attributes)
				{
					if (!a.Key.StartsWith("item-")) continue;

					var ItemInfo = FileCache.Data.Item[a.Value];
					if (ItemInfo != null && ItemInfo.alias == FilterItem.alias) return true;
				}
			}
			else if (FilterRule is NpcData NpcData)
			{
				for (byte idx = 1; idx <= 6; idx++)
				{
					var Store2 = NpcData.Attributes["store2-" + idx];
					if (Store2 is null) return false;

					if (NodeInfo.AliasText.MyEquals(Store2)) return true;
				}
			}

			return false;
		}
		#endregion



		#region 界面方法
		private void Store2Scene_Load(object sender, EventArgs e)
		{
			Store2Scene_SizeChanged(null, null);
		}

		private void Store2Scene_SizeChanged(object sender, EventArgs e)
		{
			this.ListPreview.Height = this.Height - this.ControlPanel.Bottom - 55;
		}

		private void JobSelector_SelectedChangedEvent(object sender, EventArgs e)
		{
			Ini.WriteValue("Preview", "JobFilter", this.JobSelector.TextValue);
			this.TreeView_AfterSelect(null, null);
		}



		IEnumerable<BaseRecord> npcs;

		private void ucBtnExt1_BtnClick(object sender, EventArgs e) => new SearcherScene(npcs).MyShowDialog();
		#endregion
	}
}