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