using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Xylia.Preview.Common.Interface.RecordAttribute
{
	public sealed class XElementData : AttributeCollection
	{
		#region 构造
		private readonly XmlElement data;

		public XElementData(XmlElement data) => this.data = data;
		#endregion

		#region 方法
		public string this[string param] => this.data.Attributes[param]?.Value;

		public void SetAttribute(string Name, string Value) => this.data.SetAttribute(Name, Value);

		public bool ContainsKey(string Name, out string Value)
		{
			var result = data.Attributes[Name];

			Value = result?.Value;
			return result is not null;
		}


		public override string ToString() => this.data.ToString();

		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			foreach (XmlAttribute attribute in this.data.Attributes)
				yield return new(attribute.Name, attribute.Value);

			yield break;
		}
		#endregion
	}
}