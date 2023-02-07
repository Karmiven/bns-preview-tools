using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Data.Record;
using Xylia.Preview.GameUI.Controls;
using Xylia.Preview.GameUI.Scene.Game_ToolTip.ItemTooltipPanel;
using Xylia.Preview.GameUI.Scene.Skill;

namespace Xylia.Preview.Common.Extension
{
	public static partial class RecordExtension
	{
		public static object GetParam<T>(this T Object, string ParamName)
		{
			//返回自身
			if (ParamName == Object.GetType().Name) return Object;

			//返回实例数值
			var Member = Object.GetInfo(ParamName, true);
			if (Member != null)
			{
				var value = Member.GetValue(Object);
				return value is Text text ? text.GetText() : value;
			}

			return null;
		}

		public static string GetSignal(this object EnumItem) => EnumItem.GetAttribute<Signal>()?.Description ?? (EnumItem is MemberInfo m ? m.Name : EnumItem.ToString());





		/// <summary>
		/// 消息缓存器
		/// </summary>
		public static List<string> CacheMsg = new();

		/// <summary>
		/// 通过字段名称设置字段数值（泛型）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="Case"></param>
		/// <param name="Name"></param>
		/// <param name="Value"></param>
		/// <param name="IgnoreError">忽略错误（<see langword="flase" />抛出错误，<see langword="true" />输出调试信息，<see langword="null" />不做处理)</param>
		/// <param name="IgnoreCase">忽略大小写</param>
		/// <param name="convetor"></param>
		/// <returns>转换是否成功</returns>
		public static bool SetMember<T>(this T Case, string Name, string Value, bool IgnoreCase = false, ConvertClass convetor = null)
		{
			//判断是否存在目标对象
			var TarMember = Case.GetInfo(Name, IgnoreCase);
			if (TarMember != null) return Case.SetMember(TarMember, Value, convetor);

			#region 无效处理
			//string Msg = $"不存在字段或属性 { Case.GetType().Name } -> { Name }";

			//if (IgnoreError == false) throw new Exception(Msg + $" ({ Value })");
			//else if (IgnoreError == true)
			//{
			//	//如果使用相同的消息仅显示一次设置
			//	if (UseUniqueMsg)
			//	{
			//		if (!CacheMsg.Contains(Msg)) CacheMsg.Add(Msg);
			//		else return false;
			//	}

			//	Debug.WriteLine("[debug] " + Msg + $" ({ Value })");
			//}

			return false;
			#endregion
		}

		public static bool SetMember<T>(this T Case, MemberInfo Member, string Value, ConvertClass convetor = null)
		{
			#region 初始化
			//判断是否可以写入
			if (Member is PropertyInfo PInfo && !PInfo.CanWrite) return false;
			else if (Value is null)
			{
				//值未设置时，直接将对象值赋空即可
				Member.SetValue(Case, null);
				return true;
			}

			var MemberType = Member.GetMemberType();
			#endregion


			try
			{
				if (MemberType.IsEnum)
				{
					bool Status = Value.TryParseToEnum(MemberType, out var result, true);
					if (!Status) throw new FormatException($"不存在枚举值 { Value }");

					Member.SetValue(Case, result);
				}
				else if (MemberType.IsArray)
				{
					var elementType = MemberType.GetElementType();
					var subs = Value.Trim(';').Split(';');

					Array myArray = Array.CreateInstance(elementType, subs.Length);
					for (int i = 0; i < subs.Length; ++i)
					{
						//基础数据类型处理
						//if (!MemberType.IsValueType || MemberType.IsPrimitive)

						myArray.SetValue((convetor ?? new ConvertClass()).Construct(elementType, subs[i]), i);
					}

					Member.SetValue(Case, myArray);
				}

				#region 基础数据类型处理
				//(!MemberType.IsValueType || MemberType.IsPrimitive)
				else if (MemberType == typeof(int) || MemberType == typeof(int?)) Member.SetValue(Case, int.Parse(Value));
				else if (MemberType == typeof(uint) || MemberType == typeof(uint?)) Member.SetValue(Case, uint.Parse(Value));
				else if (MemberType == typeof(long) || MemberType == typeof(long?)) Member.SetValue(Case, long.Parse(Value));
				else if (MemberType == typeof(short) || MemberType == typeof(short?)) Member.SetValue(Case, short.Parse(Value));
				else if (MemberType == typeof(bool) || MemberType == typeof(bool?)) Member.SetValue(Case, Value.ToBoolOrNull());
				else if (MemberType == typeof(float) || MemberType == typeof(float?)) Member.SetValue(Case, float.Parse(Value));
				else if (MemberType == typeof(double) || MemberType == typeof(double?)) Member.SetValue(Case, double.Parse(Value));
				else if (MemberType == typeof(byte) || MemberType == typeof(byte?)) Member.SetValue(Case, byte.Parse(Value));
				else if (MemberType == typeof(sbyte) || MemberType == typeof(sbyte?)) Member.SetValue(Case, sbyte.Parse(Value));
				else if (MemberType == typeof(DateTime) || MemberType == typeof(DateTime?))
				{
					DateTime obj = new();
					if (long.TryParse(Value, out var number)) obj = number.GetBNSTime();
					else obj = DateTime.Parse(Value);

					Member.SetValue(Case, obj);
				}
				else if (MemberType == typeof(string))
				{
					if (Value is string @string) Member.SetValue(Case, @string);
					else Member.SetValue(Case, Value);
				}
				#endregion

				else Member.SetValue(Case, (convetor ?? new ConvertClass()).Construct(MemberType, Value));
			}
			catch (Exception ee)
			{
				string MsgError = $"字段名 { Member.Name } => {Value} ({ MemberType.Name })，{ ee.Message }";
				Trace.WriteLine(MsgError);
			}

			return true;
		}

		public static Type GetMemberType(this MemberInfo MemberInfo)
		{
			if (MemberInfo is PropertyInfo property) return property.PropertyType;
			else if (MemberInfo is FieldInfo field) return field.FieldType;

			throw new Exception($"[GetMemberType] 参数错误 ({MemberInfo.GetType()})");
		}




		#region GetName
		/// <summary>
		/// 获得对象名称
		/// </summary>
		/// <param name="ObjInfo"></param>
		/// <returns></returns>
		public static string GetName(this string ObjInfo) => ObjInfo.CastObject()?.GetName() ?? ObjInfo;

		/// <summary>
		/// 获得对象名称
		/// </summary>
		/// <param name="Obj"></param>
		/// <returns></returns>
		public static string GetName(this BaseRecord Obj)
		{
			if (Obj is null) return null;
			else if (Obj is IName IName) return IName.GetName();
			else if (Obj is Attraction attraction) return attraction.GetName();

			return Obj.GetParam("Name2")?.ToString()
				?? Obj.GetParam("Name")?.ToString()
				?? Obj.alias;
		}
		#endregion

		#region GetObjIcon 
		public static ItemIconCell GetObjIcon(this string ObjInfo, string StackCount) => GetObjIcon(ObjInfo, (short)StackCount.ToInt());

		public static ItemIconCell GetObjIcon(this string ObjInfo, short StackCount = 0)
		{
			if (ObjInfo is null) return null;

			var Object = ObjInfo.Contains(':') ? ObjInfo.CastObject() : FileCache.Data.Item[ObjInfo];
			return GetObjIcon(Object, StackCount);
		}

		public static ItemIconCell GetObjIcon(this BaseRecord Object, short StackCount = 0)
		{
			if (Object is null || Object is not IPicture o) return null;
			if (Object.Attributes is null) return Object.alias.GetObjIcon(StackCount);


			return new ItemIconCell()
			{
				Image = o.MainIcon(),

				StackCount = StackCount,
				ShowStackCount = StackCount != 0,
				ObjectRef = Object,
			};
		}

		public static ItemIconCell GetObjIcon(this Bitmap Image)
		{
			return new ItemIconCell()
			{
				Image = Image,
				ShowStackCount = false,
			};
		}
		#endregion


		#region Preview
		public static void PreviewShow(this BaseRecord obj, IWin32Window window = null)
		{
			if (obj is null) return;

			var thread = new Thread(() =>
			{
				#region	GetPreview
				Form ResultFrm = null;
				if (obj is Item item) ResultFrm = new ItemTooltipPanel(item);
				else if (obj is Skill3 skill) ResultFrm = new SkillFrm(skill);
				else
				{
					Trace.WriteLine($"窗体无效 ({ obj })");
					return;
				}
				#endregion


				if (window is null) ResultFrm.ShowDialog();
				else ResultFrm.ShowDialog(window);
			});

			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}
		#endregion
	}
}