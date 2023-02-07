using Xylia.Preview.GameUI.Controls.Currency;

namespace Xylia.Preview.GameUI.Scene.Game_QuestJournal.RewardCell
{
	public partial class PriceBase : RewardCellBase
	{
		#region 初始化
		public PriceBase()
		{
			InitializeComponent();
		}
		#endregion


		#region 字段
		/// <summary>
		/// 货币数量
		/// </summary>
		public int CurrencyCount 
		{ 
			get => (int)this.priceCell1.CurrencyCount; 
			set => this.priceCell1.CurrencyCount = value; 
		}

		/// <summary>
		/// 货币类型
		/// </summary>
		public virtual CurrencyType CurrencyType 
		{ 
			get => this.priceCell1.CurrencyType; 
			set => this.priceCell1.CurrencyType = value;
		}
		#endregion
	}
}
