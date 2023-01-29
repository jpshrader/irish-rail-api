using irish_rail_api.Endpoints.StationDetails.Models;

namespace irish_rail_api.Endpoints.StationDetails.Adapters {
	public interface IStationDetailsAdapter {
		StationDetailsResource Adapt(StationDetail stationDetails);
	}
}