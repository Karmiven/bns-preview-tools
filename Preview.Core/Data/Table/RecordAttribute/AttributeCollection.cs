using System.Collections;
using System.Collections.Generic;

namespace Xylia.Preview.Common.Interface.RecordAttribute
{
	/// <summary>
	/// 对象Property集合
	/// </summary>
	public interface IAttributeCollection : IEnumerable
	{
		string this[string param] { get; }

		bool ContainsKey(string Name, out string Value);


		new IEnumerator<KeyValuePair<string, string>> GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}