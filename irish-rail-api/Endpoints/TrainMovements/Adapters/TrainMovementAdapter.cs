using irish_rail_api.Endpoints.TrainMovements.Models;

namespace irish_rail_api.Endpoints.TrainMovements.Adapters {
	public class TrainMovementAdapter : ITrainMovementAdapter {
		public TrainMovementResource Adapt(TrainMovement trainMovement) {
			return new TrainMovementResource {
				TrainCode = trainMovement.TrainCode?.Trim(),
				TrainDate = trainMovement.TrainDate,
				LocationCode = trainMovement.LocationCode,
				LocationFullName = trainMovement.LocationFullName,
				LocationOrder = trainMovement.LocationOrder,
				LocationType = GetLocationTypeString(trainMovement.LocationType),
				TrainOrigin = trainMovement.TrainOrigin,
				TrainDestination = trainMovement.TrainDestination,
				ScheduledArrival = trainMovement.ScheduledArrival,
				ScheduledDeparture = trainMovement.ScheduledDeparture,
				ExpectedArrival = trainMovement.ExpectedArrival,
				ExpectedDeparture = trainMovement.ExpectedDeparture,
				Arrival = trainMovement.Arrival,
				Departure = trainMovement.Departure,
				AutoArrival = trainMovement.AutoArrival,
				AutoDepart = trainMovement.AutoDepart,
				StopType = GetStopType(trainMovement.StopType)
			};
		}

		private static string? GetLocationTypeString(string? locationType) {
			return locationType switch {
				"S" => "Stop",
				"O" => "Origin",
				"D" => "Destination",
				"T" => "Timing",
				_ => locationType,
			};
		}

		private static string? GetStopType(string? stopType) {
			return stopType switch {
				"C" => "Current",
				"N" => "Next",
				_ => stopType
			};
		}
	}
}