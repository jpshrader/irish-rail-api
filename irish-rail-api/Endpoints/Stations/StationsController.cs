using irish_rail_api.Common;
using irish_rail_api.Common.Resources;
using irish_rail_api.Endpoints.Stations.Models;
using irish_rail_api.Endpoints.Stations.Services;
using Microsoft.AspNetCore.Mvc;

namespace irish_rail_api.Controllers.Stations {
	[ApiController]
	[ApiVersion1]
	public class StationsController : ControllerBase {
		public const string ROUTE = ApiConstants.BASE_URL + "/stations";
		public const string ROUTE_SINGLE = ROUTE + "/{stationName}";

		private readonly IStationsService stationsService;

		public StationsController(IStationsService stationsService) {
			this.stationsService = stationsService;
		}

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResourceList<StationResource>))]
		[HttpGet(ROUTE)]
		public IActionResult GetStations() {
			var result = stationsService.GetStations(ApiVersion1.VERSION);

			return Ok(result);
		}

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StationResource))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet(ROUTE_SINGLE)]
		public IActionResult GetStations(string stationName) {
			var result = stationsService.GetStation(stationName, ApiVersion1.VERSION);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
	}
}