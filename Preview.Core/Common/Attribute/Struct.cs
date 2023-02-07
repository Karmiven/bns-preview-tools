using System;

namespace Xylia.Attribute.Component
{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class FStruct : System.Attribute
	{
		public StructType Type;

		public FStruct(StructType StructType = default) => this.Type = StructType;
	}

	/// <summary>
	/// 结构类别
	/// </summary>
	public enum StructType
	{
		/// <summary>
		/// 成员对象
		/// </summary>
		Meta,

		/// <summary>
		/// 引用对象
		/// </summary>
		Ref,

		/// <summary>
		/// 状态值
		/// </summary>
		StatusValue,
	}
}