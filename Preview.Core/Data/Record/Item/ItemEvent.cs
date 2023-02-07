using System;

using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record
{
	[AliasRecord]
	public sealed class ItemEvent : BaseRecord	
	{
		[Signal("event-expiration-time")]
		public DateTime EventExpirationTime;

		public Text Name2;


		#region 方法字段
		/// <summary>
		/// 指示是否已经过期
		/// </summary>
		public bool IsExpiration => this.EventExpirationTime < DateTime.Now;
		#endregion
	}
}