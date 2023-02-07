using Xylia.Extension;

namespace Xylia.Preview.Common.Interface
{
	/// <summary>
	/// 变量参数
	/// </summary>
	public interface IArgParam
	{
		/// <summary>
		/// 获取参数名称对应的目标
		/// </summary>
		/// <param name="ParamName">参数名</param>
		/// <returns></returns>
		object ParamTarget(string ParamName);
	}


	public class ArgParam<T> : IArgParam
	{
		public T Value { get; set; }

		public override string ToString() => Value.ToString();



		object IArgParam.ParamTarget(string ParamName) => this.GetValue(ParamName, true);
	}
}