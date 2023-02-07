using System.Collections.Generic;
using System.Xml;

namespace Xylia.Match.Windows.Attribute.Data
{
	public static class ParaLoad
    {
        public static List<ParaEntity> LoadParas(XmlDocument doc)
		{
			var data = new List<ParaEntity>();
			foreach (XmlElement xmlNode in doc.SelectNodes("*/record"))
				data.Add(new ParaEntity(xmlNode));

			return data;
		}
	}
}