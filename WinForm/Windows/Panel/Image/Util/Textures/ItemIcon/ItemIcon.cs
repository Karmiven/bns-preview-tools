using System;
using System.Threading.Tasks;

using Xylia.Preview.Common.Interface.RecordAttribute;
using Xylia.Preview.Data;
using Xylia.Preview.Data.Record;

using static Xylia.Preview.Data.Record.Item;

namespace Xylia.Match.Util.Paks.Textures
{
	/// <summary>
	/// 物品图标
	/// </summary>
	public sealed class ItemIcon : IconOutBase
	{
		#region Constructor
		public ItemIcon(string GameFolder) : base(GameFolder) { }


		/// <summary>
		/// 指示是否有背景
		/// </summary>
		public bool UseBackground = false;

		/// <summary>
		/// 指示白名单模式
		/// </summary>
		public bool isWhiteList = false;

		/// <summary>
		/// 缓存文件路径
		/// </summary>
		public string ChvPath = null;
		#endregion


		#region Functions
		protected override void AnalyseSourceData()
		{
			Action("正在分析物品数据...");

			//设置并发线程数量
			var pOptions = new ParallelOptions()
			{
				//MaxDegreeOfParallelism = 6,
			};


			//Load 外部文件
			var lst = ChvLoad.LoadData(ChvPath);

			//Load 物品数据
			Parallel.ForEach(set.Item, pOptions, (item) =>
			{
				//使用原始属性
				var record = ((DbData)item.Attributes).record;

				int MainID = record.RecordId;
				if (isWhiteList && (lst is null || !lst.Contains(MainID))) return;
				if (!isWhiteList && (lst != null && lst.Contains(MainID))) return;


				#region 获取数据
				var Data = record.Data;

				var Grade = Data[LocDefine.Grade];
				var Name2 = set.TextData[BitConverter.ToInt32(Data, LocDefine.Name2)].GetText();
				var IconId = BitConverter.ToInt32(Data, LocDefine.IconId);
				var IconIdx = BitConverter.ToInt16(Data, LocDefine.IconId + 8);

				//获取 GroceryType
				byte GroceryType = 0;
				if (record.SubclassType == 2) GroceryType = Data[LocDefine.GroceryType];
				#endregion


				this.QuoteInfos.Add(new ItemQuoteInfo()
				{
					MainId = MainID,
					Alias = record.StringLookup.GetString(0),
					Name = Name2,
					Grade = Grade,
					GroceryType = (GroceryTypeSeq)GroceryType,

					TextureAlias = IconId.ToString(),
					IconIndex = IconIdx,

					NoBG = !this.UseBackground,
				});
			});
		}
		#endregion
	}
}