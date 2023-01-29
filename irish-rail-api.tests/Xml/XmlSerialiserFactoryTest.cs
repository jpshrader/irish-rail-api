using irish_rail_api.Common.Xml;
using irish_rail_api.Controllers.Trains.Models;
using irish_rail_api.Models;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Xunit;

namespace irish_rail_api.test.Xml {
	public class XmlSerialiserFactoryTest {
		[Fact]
		public void XmlSerializerFactory_GetStationSerialiser_ReturnsStationList() {
			var stationsXml = @"<ArrayOfObjStation xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://api.irishrail.ie/realtime/"">
                                    <objStation>
                                        <StationDesc>Belfast</StationDesc>
                                        <StationAlias/>
                                        <StationLatitude>54.6123</StationLatitude>
                                        <StationLongitude>-5.91744</StationLongitude>
                                        <StationCode>BFSTC</StationCode>
                                        <StationId>228</StationId>
                                    </objStation>
                             </ArrayOfObjStation>";

			var result = DeserialiseXml<Station>(stationsXml, XmlSerialiserFactory.GetXmlSerialiser<Station>());

			Assert.NotNull(result);

			var stationResult = result?.Items[0];
			Assert.Single(result?.Items);
			Assert.Equal("Belfast", stationResult?.StationDesc);
		}

		[Fact]
		public void XmlSerializerFactory_GetTrainSerialiser_ReturnsTrainList() {
			var trainsXml = @"<ArrayOfObjTrainPositions  xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://api.irishrail.ie/realtime/"">
                                    <objTrainPositions>
                                        <TrainStatus>N</TrainStatus>
                                        <TrainLatitude>51.8491</TrainLatitude>
                                        <TrainLongitude>-8.29956</TrainLongitude>
                                        <TrainCode>P230</TrainCode>
                                        <TrainDate>08 Oct 2019</TrainDate>
                                        <PublicMessage>P230\nCobh to Cork\nExpected Departure 06:00</PublicMessage>
                                        <Direction>To Cork</Direction>
                                    </objTrainPositions>
                             </ArrayOfObjTrainPositions >";

			var result = DeserialiseXml<Train>(trainsXml, XmlSerialiserFactory.GetXmlSerialiser<Train>());

			Assert.NotNull(result);

			var trainList = result?.Items[0];
			Assert.Single(result?.Items);
			Assert.Equal("To Cork", trainList?.Direction);
		}

		private static IXmlNode<T>? DeserialiseXml<T>(string xml, XmlSerializer xmlSerialiser) {
			return xmlSerialiser.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xml))) as IXmlNode<T>;
		}
	}
}