﻿using System;

using Xylia.Extension;
using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Common.Cast
{
	public static class Cast
	{
		#region 转换枚举
		public static T CastSeq<T>(this string SeqValue) where T : Enum => SeqValue.ToEnum<T>();

		public static object CastSeq(this string SeqValue, string SeqName)
		{
			if (!SeqName.TryParseToEnum<SeqType>(out var SeqType)) return null;
			else if (SeqType == SeqType.KeyCap) return CastSeq<KeyCode>(SeqValue);
			else if (SeqType == SeqType.KeyCommand) return CastSeq<KeyCommandSeq>(SeqValue);

			throw new InvalidCastException($"Cast Failed: {SeqName} > {SeqValue}");
		}
		#endregion

		#region 转换对象
		public static BaseRecord CastObject(this string ObjInfo)
		{
			if (string.IsNullOrWhiteSpace(ObjInfo)) return default;
			if (ObjInfo.Contains(':'))
			{
				var tmp = ObjInfo.Split(':');

				var obj = CastObject(tmp[1]?.Trim(), tmp[0]?.Trim());
				if (obj != null) return obj;
			}

			System.Diagnostics.Debug.WriteLine($"Cast Failed: {ObjInfo}");
			return default;
		}

		private static BaseRecord CastObject(this string DataKey, string DataTableName)
		{
			if (string.IsNullOrWhiteSpace(DataKey)) return default;
			if (DataTableName.MyEquals("skill")) return FileCache.Data.Skill3[DataKey];
			if (DataTableName.MyEquals("tooltip")) return FileCache.Data.TextData[DataKey];

			//通过反射获取数据
			var DataTable = FileCache.Data.GetValue(DataTableName, true);
			return (BaseRecord)DataTable?.GetType()
				.GetMethod("get_Item", ClassExtension.Flags, new Type[] { typeof(string) })?
				.Invoke(DataTable, DataKey);
		}
		#endregion
	}
}