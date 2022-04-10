using irish_rail_api.Common.Resources;
using irish_rail_api.Endpoints.Stations.Models;

namespace irish_rail_api.Endpoints.Stations.Services {
	public interface IStationsService {
		ResourceList<StationResource> GetStations(string apiVersion);

		StationResource? GetStation(string stationName, string apiVersion);
	}
}
