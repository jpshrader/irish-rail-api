using irish_rail_api.Endpoints.StationDetails.Models;

namespace irish_rail_api.Endpoints.StationDetails.Adapters {
	public class StationDetailsAdapter : IStationDetailsAdapter {
		public StationDetailsResource Adapt(StationDetail stationData) {
			return new StationDetailsResource {
				StationCode = stationData.Stationcode,
				StationFullName = stationData.Stationfullname,
				TrainCode = stationData.Traincode?.Trim(),
				Origin = stationData.Origin,
				Destination = stationData.Destination,
				DestinationTime = stationData.Destinationtime,
				DueIn = stationData.Duein,
				Late = stationData.Late,
				ScheduledDeparture = stationData.Schdepart,
				ScheduledArrival = stationData.Scharrival,
				ExpectedDeparture = stationData.Expdepart,
				ExpectedArrival = stationData.Exparrival,
				TrainDate = stationData.Traindate,
				OriginTime = stationData.Origintime,
				TrainType = stationData.Traintype,
				LocationType = GetLocationTypeString(stationData.Locationtype),
				StaLastLocationTus = stationData.StaLastlocationtus
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
	}
}
