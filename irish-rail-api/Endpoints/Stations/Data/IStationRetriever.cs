using irish_rail_api.Models;

namespace irish_rail_api.Endpoints.Stations.Data {
	public interface IStationRetriever {
		IEnumerable<Station> GetStations();
	}
}