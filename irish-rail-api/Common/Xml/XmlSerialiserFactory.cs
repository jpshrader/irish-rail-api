using System.Xml.Serialization;

namespace irish_rail_api.Common.Xml {
	public static class XmlSerialiserFactory {
		public static XmlSerializer GetXmlSerialiser<T>() {
			var xmlSerialiserType = typeof(T).Assembly.GetTypes()
				.Single(t => t.GetInterfaces().Contains(typeof(IXmlNode<T>)));

			return new XmlSerializer(xmlSerialiserType);
		}
	}
}
