using System.ComponentModel;

namespace Xylia.Preview.Common.Seq
{
	[DefaultValue(eq)]
	public enum Op
	{
		/// <summary>
		/// 相等
		/// </summary>
		eq,

		/// <summary>
		/// 不相等
		/// </summary>
		neq,

		/// <summary>
		/// 大于
		/// </summary>
		gt,

		/// <summary>
		/// 大于等于
		/// </summary>
		ge,

		/// <summary>
		/// 小于
		/// </summary>
		lt,

		/// <summary>
		/// 小于等于
		/// </summary>
		le,
	}




	[DefaultValue(and)]
	public enum OpCheck
	{
		and,

		or,
	}

	public enum OpCheck2
	{
		or,

		and,
	}
}