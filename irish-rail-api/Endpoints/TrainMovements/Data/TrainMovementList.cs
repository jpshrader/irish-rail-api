using irish_rail_api.Common.Xml;
using irish_rail_api.Endpoints.TrainMovements.Models;
using System.Xml.Serialization;

namespace irish_rail_api.TrainMovements.Data {
	[XmlRoot("ArrayOfObjTrainMovements", Namespace = "http://api.irishrail.ie/realtime/")]
	public class TrainMovementList : IXmlNode<TrainMovement> {
		[XmlElement("objTrainMovements")]
		public TrainMovement[] Items { get; set; }
	}
}
