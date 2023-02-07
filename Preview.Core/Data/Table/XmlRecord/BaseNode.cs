using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using Xylia.Preview.Common.Extension;
using Xylia.Attribute.Component;
using Xylia.Extension;

namespace Xylia.Preview.Data.Table.XmlRecord
{
	public abstract class BaseNode
	{
		public virtual void LoadData(XmlElement xe) => LoadData(this, xe);




		#region 静态方法
		public static void LoadData(object T, XmlElement xe)
		{
			var convert = new RefConvert();
			foreach (XmlAttribute Attr in xe.Attributes)
			{
				// 通过 TypeBaseNode 处理
				if (Attr.Name == "type") continue;

				T.SetMember(Attr.Name, Attr.Value, true, convert);
			}
		}

		public static List<T> LoadChildren<T>(XmlElement xe, string NodeName = null) where T : BaseNode, new()
		{
			NodeName ??= typeof(T).Name.ToLower();

			var records = new List<T>();
			foreach (XmlElement data in xe.SelectNodes("./" + NodeName))
			{
				var record = new T();
				//record.TableIndex = (uint)records.Count;
				record.LoadData(data);
				records.Add(record);
			}

			return records;
		}

		public static XmlNode Serialize(object T, XmlDocument doc, ReleaseSide side = default, bool HasChild = true, string NodeName = null)
		{
			//如果未传递节点名，则获取当前节点名称
			NodeName ??= T.GetAttribute<Signal>()?.Description ?? T.GetType().Name.ToLower();
			var Node = doc.CreateElement(NodeName);

			#region 实例化节点和字段名
			foreach (var pinfo in T.GetType().GetFields(ClassExtension.Flags))
			{
				#region 初始化
				//不处理结构对象
				if (pinfo.ContainAttribute(out FStruct st)) continue;

				//去除服务端专用字段
				if (pinfo.ContainAttribute(out Side fside))
				{
					if (side == ReleaseSide.Client && fside.SideType == Side.Type.Server) continue;
					else if (side == ReleaseSide.Server && fside.SideType == Side.Type.Client) continue;
				}

				var ObjVal = pinfo.GetValue(T);
				if (ObjVal is null) continue;
				#endregion


				#region 默认值判断
				//默认值为 Null，则表示任何值都应该显示
				if (pinfo.ContainAttribute(out DefaultValueAttribute DefVal))
				{
					if (DefVal.Value != null && DefVal.Value.Equals(ObjVal))
						continue;
				}
				else if (pinfo.FieldType == typeof(bool) && !(bool)ObjVal) continue;
				else if (pinfo.FieldType == typeof(int) && (int)ObjVal == 0) continue;
				else if (pinfo.FieldType == typeof(byte) && (byte)ObjVal == 0) continue;
				else if (pinfo.FieldType == typeof(long) && (long)ObjVal == 0) continue;
				else if (pinfo.FieldType == typeof(short) && (short)ObjVal == 0) continue;
				else if (pinfo.FieldType == typeof(float) && (float)ObjVal == 0) continue;
				else if (pinfo.FieldType == typeof(double) && (double)ObjVal == 0) continue;
				else if (pinfo.FieldType.IsEnum)
				{
					var EnumValue = ObjVal.ToString();

					//如果不存在，则判断枚举对象自身的默认值信息
					if (pinfo.FieldType.ContainAttribute(out DefaultValueAttribute DefVal2))
					{
						//直接比较
						if (pinfo.FieldType == DefVal2.Value.GetType() && DefVal2.Value.Equals(ObjVal)) continue;
					}

					else if (EnumValue.MyEquals("none")) continue;
				}
				#endregion

				#region 获得对象值
				string Value = ObjVal.ToString();
				if (pinfo.FieldType == typeof(bool)) Value = (bool)ObjVal ? "y" : "n";
				else if (pinfo.FieldType == typeof(float)) Value = ((float)ObjVal).ToString("0.0001");
				else if (pinfo.FieldType.IsEnum)
				{
					if (ObjVal.ContainAttribute(out Signal EnumDescA) && !string.IsNullOrWhiteSpace(EnumDescA.Description))
						Value = EnumDescA.Description;

					Value = Value.ToLower();
				}
				#endregion

				#region 获得对象名
				string Key = pinfo.Name.ToLower();
				if (pinfo.ContainAttribute(out Signal descA) && !string.IsNullOrWhiteSpace(descA.Description))
					Key = descA.Description;

				//Sort.Method.StrCompare(x.Key, y.Key)
				Node.SetAttribute(Key, Value);
				#endregion
			}
			#endregion

			if (HasChild)
				SerializeChildren(T, doc, Node, side);

			return Node;
		}

		public static void SerializeChildren(object T, XmlDocument doc, XmlElement parent, ReleaseSide side)
		{
			foreach (var Field in T.GetType().GetFields(ClassExtension.Flags))
			{
				if (Field.FieldType.IsValueType) continue;

				//只需要处理结构字段
				if (Field.ContainAttribute(out FStruct @struct) && @struct.Type == StructType.Meta)
				{
					var obj = Field.GetValue(T);
					if (obj is null) continue;
					if (obj.GetType().GetGenericTypeDefinition() == typeof(Lazy<>))
						obj = obj.GetValue("Value");


					SetData(obj);
					void SetData(object obj)
					{
						if (obj is null) return;
						else if (obj is BaseNode) parent.AppendChild(Serialize(obj, doc, side));
						else if (obj is IEnumerable enumerable) foreach (var t in enumerable) SetData(t);
						else Trace.WriteLine($"[Serialize Failed] { Field.Name } ,{ obj.GetType() }");
					}
				}
			}
		}
		#endregion
	}



	/// <summary>
	/// 子类 基节点
	/// </summary>
	/// <typeparam name="SubType"></typeparam>
	public abstract class TypeBaseNode<SubType> : BaseNode where SubType : Enum
	{
		public SubType Type;
	}
}