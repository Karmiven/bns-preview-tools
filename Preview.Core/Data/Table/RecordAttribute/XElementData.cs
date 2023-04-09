using System.Collections.Generic;
using System.Xml;

namespace Xylia.Preview.Common.Interface.RecordAttribute
{
	public sealed class XElementData : IAttributeCollection
	{
		#region Constructor
		public readonly XmlElement data;

		public XElementData(XmlElement data) => this.data = data;
		#endregion

		#region Functions
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