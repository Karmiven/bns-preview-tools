namespace Xylia.Preview.Common.Arg
{
	/// <summary>
	/// 目标表达式
	/// </summary>
	public struct Script_obj
	{
		#region Constructor
		public Script_obj(string Text) => this.Temp = Text;
		#endregion

		/// <summary>
		/// 表达式整体
		/// </summary>
		public string Temp;




		//public object Object;
	}
}