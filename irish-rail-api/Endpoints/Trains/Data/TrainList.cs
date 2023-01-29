using irish_rail_api.Common.Xml;
using irish_rail_api.Controllers.Trains.Models;
using System.Xml.Serialization;

namespace irish_rail_api.Trains.Data {
	[XmlRoot("ArrayOfObjTrainPositions", Namespace = "http://api.irishrail.ie/realtime/")]
	public class TrainMovementList : IXmlNode<Train> {
		[XmlElement("objTrainPositions")]
		public Train[] Items { get; set; }
	}
}