using System.Reflection;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Common.Interface.RecordAttribute;
using Xylia.Preview.Data.Table;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record
{
	public class BaseRecord : IArgParam
	{
		#region 设定字段
		public AttributeCollection Attributes;

		public bool ContainsAttribute(string Name, out string Value) => this.Attributes.ContainsKey(Name, out Value) && Value != null;

		public void Init()
		{
			if (Attributes.ContainsKey("alias", out var _alias))
				this.alias = _alias.ToString();

			var convert = new RefConvert();
			foreach (var field in this.GetType().GetFields(ClassExtension.Flags | BindingFlags.DeclaredOnly))
			{
				var Name = field.GetSignal();
				if (this.Attributes.ContainsKey(Name, out var Value))
					this.SetMember(field, Value, convert);
			}
		}
		#endregion

		#region 属性字段	
		public virtual int Key() => int.TryParse(this.Attributes?["id"], out var @int) ? @int : (int)(this.TableIndex + 1);

		/// <summary>
		/// 内部索引
		/// </summary>
		[FStruct(StructType.StatusValue)]
		public uint TableIndex;


		public string alias;
		#endregion

		#region 接口字段
		public override string ToString() => this.GetType().Name + ":" + (this.alias ?? this.Key().ToString());

		object IArgParam.ParamTarget(string ParamName) => this.GetParam(ParamName) ?? this.Attributes[ParamName];



		public static bool operator ==(BaseRecord a, BaseRecord b)
		{
			// If both are null, or both are same instance, return true.
			if (ReferenceEquals(a, b)) return true;

			// If one is null, but not both, return false.
			if (a is null || b is null) return false;
			if (a.GetType() != b.GetType()) return false;

			// Return true if the fields match:
			if (a.alias != null && a.alias != b.alias) return false;


			return true;
		}

		public static bool operator !=(BaseRecord a, BaseRecord b)
		{
			return !(a == b);
		}
		#endregion


		public virtual void LoadData(AttributeCollection data)
		{
			this.Attributes = data;
			this.Init();
		}

		public virtual void LoadData(XmlElement data)
		{
			this.Attributes = new XElementData(data);
			this.Init();
		}


		public XmlDocument XmlInfo(ReleaseSide side = default)
		{
			var doc = new XmlDocument();

			//创建根结点
			XmlElement table = doc.CreateElement("table");
			doc.AppendChild(table);
			table.SetAttribute("release-module", "");
			table.SetAttribute("release-side", side.ToString().ToLower());
			table.SetAttribute("type", "");
			table.SetAttribute("version", $"");
			table.AppendChild(BaseNode.Serialize(this, doc));

			return doc;
		}
	}
}