using Xylia.Preview.Common.Interface;
using Xylia.Preview.GameUI.Controls.Currency;

namespace Xylia.Preview.Common.Arg
{
	public sealed class Integer : ArgParam<float>
	{
		public Integer(float Value) => this.Value = Value;



		public string FloatDot0 => $"#{Value} FloatDot0";

		public string FloatDot1 => $"#{Value} FloatDot1";

		public string FloatDot2 => $"#{Value} FloatDot2";

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