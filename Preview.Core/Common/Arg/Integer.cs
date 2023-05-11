using Xylia.Preview.Common.Interface;
using Xylia.Preview.GameUI.Controls.Currency;

namespace Xylia.Preview.Common.Arg
{
	public sealed class Integer : ArgParam<float>
	{
		public Integer(float Value) => this.Value = Value;



		public string FloatDot0 => (Value / 10).ToString("#0");

		public string FloatDot1 => (Value / 10).ToString("#0.0");

		public string FloatDot2 => (Value / 10).ToString("#0.00");

		public string Dategmtime24 => $"#{Value} dategmtime24";

		public string Money => new MoneyConvert((int)Value).ToString();

		public string MoneyDefault => $"#{Value} MoneyDefault";

		public string MoneyNonTooltip => $"#{Value} MoneyNonTooltip";

		public string Time => $"#{Value}Time 时间";

		public string Timedate => $"#{Value}Timedate 时间";

		public string Timedhm => $"#{Value}Timedhm 时间";

		public string Timehm => $"#{Value}Timehm 时间";

		public string Timeymd => $"#{Value}Timeymd 时间";

		public string TimeRoundDown => $"#{Value}TimeRoundDown 倒数时间";
	}
}