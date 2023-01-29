using irish_rail_api.Common;
using irish_rail_api.Common.Resources;
using irish_rail_api.Controllers.Stations;
using irish_rail_api.Endpoints.StationDetails.Models;
using irish_rail_api.Endpoints.StationDetails.Services;
using Microsoft.AspNetCore.Mvc;

namespace irish_rail_api.Endpoints.Stations.StationDetails {
	[ApiController]
	[ApiVersion1]
	public class StationDetailsController : ControllerBase {
		public const string ROUTE = StationsController.ROUTE_SINGLE + "/details";

		private readonly IStationDetailsService stationDetailsService;

		public StationDetailsController(IStationDetailsService stationDetailsService) {
			this.stationDetailsService = stationDetailsService;
		}

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResourceList<StationDetailsResource>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet(ROUTE)]
		public IActionResult GetDetails(string stationName) {
			var result = stationDetailsService.GetStationDetails(stationName, ApiVersion1.VERSION);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
	}
}