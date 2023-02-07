using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.GameUI.Controls.List;
using Xylia.Preview.GameUI.Scene.Game_ItemStore;

namespace Xylia.Preview.GameUI.Scene.Game_RandomStore
{
	public sealed partial class Game_RandomStoreScene : StoreScene
	{
		#region 字段
		readonly Dictionary<string, Dictionary<int, RandomStoreItem>> RandomStoreItemGroups = new();

		readonly Dictionary<GroupType, TreeNode> MainNode = new();

		public Game_RandomStoreScene() : base()
		{
			this.InitializeComponent();


			//this.ListPreview.MainMenu.Items.Add("设置当前组合概率");
			//this.ListPreview.MainMenu.Items.Add("新增聚灵阁组合");

			this.TreeView.Nodes.Clear();
			this.MainNode.Clear();

			foreach (var seq in Enum.GetValues<GroupType>())
			{
				var TreeNode = new TreeNode(seq.GetDescription());
				this.TreeView.Nodes.Add(TreeNode);

				MainNode.Add(seq, TreeNode);
			}
		}
		#endregion


		#region 方法
		protected override void LoadData()
		{
			//先进行分组
			foreach (var Record in FileCache.Data.RandomStoreItem)
			{
				if (Record.alias.RegexMatch("[0-9]*$", out string Result))
				{
					int Idx = int.Parse(Result);
					string GroupAlias = Record.alias.RegexReplace("_[0-9]*$");

					if (!RandomStoreItemGroups.ContainsKey(GroupAlias))
					{
						RandomStoreItemGroups.Add(GroupAlias, new Dictionary<int, RandomStoreItem>());

						//显示的文本名称
						GroupType CurGroupType;

						#region 判断应该追加到哪个母节点
						if (GroupAlias.MyContains("gold"))
						{
							if (GroupAlias.MyContains("rare")) CurGroupType = GroupType.GoldRare;
							else CurGroupType = GroupType.GoldNormal;
						}
						else
						{
							if (GroupAlias.MyContains("awesome")) CurGroupType = GroupType.Awesome;
							else if (GroupAlias.MyContains("rare")) CurGroupType = GroupType.Rare;
							else CurGroupType = GroupType.Normal;
						}

						TreeNode ParentNode = this.MainNode[CurGroupType];
						#endregion

						var Node = ParentNode.Nodes.Add(GroupAlias);
						this.TreeNodeInfo.Add(Node, new NodeInfo(GroupAlias, Node));
					}

					RandomStoreItemGroups[GroupAlias].Add(Idx, Record);
				}
			}

			this.MainNode[GroupType.Rare].ExpandAll();
		}

		protected override void ShowStoreContent(string GroupAlias)
		{
			#region 初始化数据
			if (!RandomStoreItemGroups.ContainsKey(GroupAlias)) return;

			this.ListPreview.Name = GroupAlias;
			var CurRandomStoreItems = this.RandomStoreItemGroups[GroupAlias];
			#endregion

			#region 显示内容
			var Cells = new List<ListCell>();
			foreach (var RandomStoreItem in CurRandomStoreItems.Values)
			{
				#region 加载实例数据
				var ItemInfo = FileCache.Data.Item[RandomStoreItem.Item];

				//加载物品购买价格（聚灵阁只有 金币 & 第一个物品)
				var BuyPrice = new ItemBuyPrice()
				{
					RequiredItem1 = RandomStoreItem.ItemPriceItem,
					RequiredItemCount1 = RandomStoreItem.ItemPriceItemAmount,

					Money = RandomStoreItem.ItemPriceMoney,
				};
				#endregion

				//保证控件不会跨线程调用
				this.ListPreview.Invoke(new(() =>
				{
					var Store2ItemCell = new Store2ItemCell(ItemInfo, BuyPrice)
					{
						StoreBundleCount = RandomStoreItem.ItemCount,
					};

					Cells.Add(Store2ItemCell);
				}));
			}

			this.ListPreview.Invoke(() => this.ListPreview.Cells = Cells);
			#endregion
		}

		protected override bool FilterNode(NodeInfo NodeInfo, object FilterRule)
		{
			//如果搜索条件是物品信息，那么再搜索可购买物品
			if (FilterRule is Item FilterItem)
			{
				//遍历可购买物品字段
				foreach (var ItemGroup in this.RandomStoreItemGroups[NodeInfo.AliasText].Values)
				{
					var item = FileCache.Data.Item[ItemGroup.Item];
					if (item != null && item.alias == FilterItem.alias) return true;
				}
			}

			return false;
		}
		#endregion
	}



	public enum GroupType
	{
		[Description("聚灵阁 稀有")]
		Rare,

		[Description("聚灵阁 一般")]
		Normal,

		[Description("聚灵阁 鸿运")]
		Awesome,

		[Description("金币聚灵阁 稀有")]
		GoldRare,

		[Description("金币聚灵阁 一般")]
		GoldNormal,
	}
}