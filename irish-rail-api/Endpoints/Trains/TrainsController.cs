using irish_rail_api.Common;
using irish_rail_api.Common.Resources;
using irish_rail_api.Controllers.Trains.Models;
using irish_rail_api.Endpoints.Trains.Services;
using Microsoft.AspNetCore.Mvc;

namespace irish_rail_api.Controllers.Trains {
	[ApiController]
	[ApiVersion1]
	public class TrainsController : ControllerBase {
		public const string ROUTE = ApiConstants.BASE_URL + "/trains";
		public const string ROUTE_SINGLE = ROUTE + "/{trainCode}";
		private readonly ITrainsService trainsService;

		public TrainsController(ITrainsService trainsService) {
			this.trainsService = trainsService;
		}

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResourceList<TrainResource>))]
		[HttpGet(ROUTE)]
		public IActionResult GetTrains() {
			var result = trainsService.GetTrains(ApiVersion1.VERSION);

			return Ok(result);
		}

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TrainResource))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet(ROUTE_SINGLE)]
		public IActionResult GetTrain(string trainCode) {
			var result = trainsService.GetTrain(trainCode, ApiVersion1.VERSION);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
	}
}