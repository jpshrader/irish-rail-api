using irish_rail_api.Endpoints.StationDetails.Models;

namespace irish_rail_api.Endpoints.StationDetails.Data {
	public interface IStationDetailsRetriever {
		IEnumerable<StationDetail> GetStationData(string stationId);
	}
}