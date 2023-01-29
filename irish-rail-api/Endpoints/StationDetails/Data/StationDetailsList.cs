using irish_rail_api.Common.Xml;
using irish_rail_api.Endpoints.StationDetails.Models;
using System.Xml.Serialization;

namespace irish_rail_api.Endpoints.StationDetails.Data {
	[XmlRoot("ArrayOfObjStationData", Namespace = "http://api.irishrail.ie/realtime/")]
	public class StationDetailsList : IXmlNode<StationDetail> {
		[XmlElement("objStationData")]
		public StationDetail[] Items { get; set; }
	}
}