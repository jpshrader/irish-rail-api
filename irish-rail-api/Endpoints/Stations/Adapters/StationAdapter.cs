using irish_rail_api.Common.Resources;
using irish_rail_api.Controllers.Stations;
using irish_rail_api.Endpoints.Stations.Models;
using irish_rail_api.Endpoints.Stations.StationDetails;
using irish_rail_api.Models;

namespace irish_rail_api.Endpoints.Stations.Adapters {
	public class StationAdapter : IStationAdapter {
		public StationResource Adapt(Station station, string apiVersion) {
			return new StationResource {
				Id = station.StationId,
				Name = station.StationDesc,
				Code = station.StationCode?.Trim(),
				Alias = station.StationAlias,
				Latitude = station.StationLatitude,
				Links = new HateoasLink[] {
					HateoasLink.BuildGetLink(StationsController.ROUTE_SINGLE, HateoasLink.SELF, apiVersion, station.StationDesc),
					HateoasLink.BuildGetLink(StationDetailsController.ROUTE, HateoasLink.SELF_DETAILED, apiVersion, station.StationDesc)
				}
			};
		}
	}
}
