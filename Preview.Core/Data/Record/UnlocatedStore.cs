﻿using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record
{
	public sealed class UnlocatedStore : BaseRecord
	{
		#region 字段
		public Store2 Store2;

		[Signal("no-more-use")]
		public bool NoMoreUse;

		[Signal("unlocated-store-type")]
		public Type UnlocatedStoreType;
		#endregion


		#region 枚举
		/// <summary>
		/// 非固定商店分类
		/// </summary>
		public enum Type
		{
			UnlocatedNone = 0,
			UnlocatedStore,
			AccountStore,

			SoulBoostStore1,
			SoulBoostStore2,
			SoulBoostStore3,
			SoulBoostStore4,
			SoulBoostStore5,
			SoulBoostStore6,
		}
		#endregion
	}
}