using irish_rail_api.Common.Access;
using irish_rail_api.Endpoints.StationDetails.Models;

namespace irish_rail_api.Endpoints.StationDetails.Data {
	public class StationDetailsRetriever : IStationDetailsRetriever {
		private const string GET_STATION_DATA = "http://api.irishrail.ie/realtime/realtime.asmx/getStationDataByNameXML?StationDesc=";

		private readonly IApiAccess<StationDetail> apiAccess;

		public StationDetailsRetriever(IApiAccess<StationDetail> apiAccess) {
			this.apiAccess = apiAccess;
		}

		public IEnumerable<StationDetail> GetStationData(string stationId) {
			return apiAccess.GetResources(new Uri(GET_STATION_DATA + stationId));
		}
	}
}
