using irish_rail_api.Common.Resources;
using irish_rail_api.Endpoints.StationDetails.Models;

namespace irish_rail_api.Endpoints.StationDetails.Services {
	public interface IStationDetailsService {
		ResourceList<StationDetailsResource> GetStationDetails(string stationName, string apiVersion);
	}
}