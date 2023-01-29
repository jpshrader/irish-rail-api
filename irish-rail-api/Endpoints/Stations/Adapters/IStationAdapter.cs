using irish_rail_api.Endpoints.Stations.Models;
using irish_rail_api.Models;

namespace irish_rail_api.Endpoints.Stations.Adapters {
	public interface IStationAdapter {
		StationResource Adapt(Station station, string apiVersion);
	}
}