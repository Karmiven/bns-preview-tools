using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Preview.Common.Extension;

namespace Xylia.Preview.Data.Table.XmlRecord
{
	public abstract class BaseNode
	{
		public virtual void LoadData(XmlElement xe) => LoadData(this, xe);


		#region 静态方法
		public static void LoadData(object T, XmlElement xe)
		{
			var convert = new RefConvert();
			foreach (XmlAttribute attr in xe.Attributes)
			{
				if (attr.Name == "type") continue;

				T.SetMember(attr.Name, attr.Value, true, convert);
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

			//实例化节点和字段名
			foreach (var field in T.GetType().GetFields(ClassExtension.Flags))
			{
				if (field.ContainAttribute(out FStruct st))
				{
					//if (Field.FieldType.IsValueType) continue;

					if (HasChild && st.Type == StructType.Meta)
					{
						var obj = field.GetValue(T);
						if (obj is null) continue;
						if (obj.GetType().GetGenericTypeDefinition() == typeof(Lazy<>))
							obj = obj.GetValue("Value");


						SetData(obj);
						void SetData(object obj)
						{
							if (obj is null) return;
							else if (obj is BaseNode) Node.AppendChild(Serialize(obj, doc, side));
							else if (obj is IEnumerable enumerable) foreach (var t in enumerable) SetData(t);
							else Trace.WriteLine($"[Serialize Failed] { field.Name } ,{ obj.GetType() }");
						}
					}
				}
				else
				{
					//去除服务端专用字段
					if (field.ContainAttribute(out Side fside))
					{
						if (side == ReleaseSide.Client && fside.SideType == Side.Type.Server) continue;
						else if (side == ReleaseSide.Server && fside.SideType == Side.Type.Client) continue;
					}

					var ObjVal = field.GetValue(T);
					if (ObjVal is null) continue;

					#region 默认值判断
					//默认值为 Null，则表示任何值都应该显示
					if (field.ContainAttribute(out DefaultValueAttribute DefVal))
					{
						if (DefVal.Value != null && DefVal.Value.Equals(ObjVal))
							continue;
					}
					else if (field.FieldType == typeof(bool) && !(bool)ObjVal) continue;
					else if (field.FieldType == typeof(int) && (int)ObjVal == 0) continue;
					else if (field.FieldType == typeof(byte) && (byte)ObjVal == 0) continue;
					else if (field.FieldType == typeof(long) && (long)ObjVal == 0) continue;
					else if (field.FieldType == typeof(short) && (short)ObjVal == 0) continue;
					else if (field.FieldType == typeof(float) && (float)ObjVal == 0) continue;
					else if (field.FieldType == typeof(double) && (double)ObjVal == 0) continue;
					else if (field.FieldType.IsEnum)
					{
						var EnumValue = ObjVal.ToString();

						//如果不存在，则判断枚举对象自身的默认值信息
						if (field.FieldType.ContainAttribute(out DefaultValueAttribute DefVal2))
						{
							if (field.FieldType == DefVal2.Value.GetType() && DefVal2.Value.Equals(ObjVal)) continue;
						}

						else if (EnumValue.MyEquals("none")) continue;
					}
					#endregion

					#region 获得对象值
					string Value = ObjVal.ToString();
					if (field.FieldType == typeof(bool)) Value = (bool)ObjVal ? "y" : "n";
					else if (field.FieldType == typeof(float)) Value = ((float)ObjVal).ToString("0.0001");
					else if (field.FieldType.IsEnum)
					{
						if (ObjVal.ContainAttribute(out Signal EnumDescA) && !string.IsNullOrWhiteSpace(EnumDescA.Description))
							Value = EnumDescA.Description;

						Value = Value.ToLower();
					}
					#endregion

					#region 获得对象名
					string Key = field.Name.ToLower();
					if (field.ContainAttribute(out Signal descA) && !string.IsNullOrWhiteSpace(descA.Description))
						Key = descA.Description;

					Node.SetAttribute(Key, Value);
					#endregion
				}
			}

			return Node;
		}
		#endregion
	}

	public abstract class TypeBaseNode<SubType> : BaseNode where SubType : Enum
	{
		public SubType Type;
	}
}