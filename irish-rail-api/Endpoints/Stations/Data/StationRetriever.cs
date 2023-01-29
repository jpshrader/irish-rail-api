using irish_rail_api.Common.Access;
using irish_rail_api.Models;

namespace irish_rail_api.Endpoints.Stations.Data {
	public class StationRetriever : IStationRetriever {
		private const string GET_ALL_STATIONS_URL = "http://api.irishrail.ie/realtime/realtime.asmx/getAllStationsXML";

		private readonly IApiAccess<Station> apiAccess;

		public StationRetriever(IApiAccess<Station> apiAccess) {
			this.apiAccess = apiAccess;
		}

		public IEnumerable<Station> GetStations() {
			return apiAccess.GetResources(new Uri(GET_ALL_STATIONS_URL));
		}
	}
}