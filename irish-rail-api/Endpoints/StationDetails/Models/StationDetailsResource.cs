using irish_rail_api.Common.Resources;

namespace irish_rail_api.Endpoints.StationDetails.Models {
	public class StationDetailsResource : Resource {
		public string? StationFullName { get; set; }

		public string? StationCode { get; set; }

		public string? TrainCode { get; set; }

		public string? TrainDate { get; set; }

		public string? Origin { get; set; }

		public string? Destination { get; set; }

		public string? OriginTime { get; set; }

		public string? DestinationTime { get; set; }

		public string? StaLastLocationTus { get; set; }

		public int DueIn { get; set; }

		public int Late { get; set; }

		public string? ExpectedArrival { get; set; }

		public string? ExpectedDeparture { get; set; }

		public string? ScheduledArrival { get; set; }

		public string? ScheduledDeparture { get; set; }

		public string? TrainType { get; set; }

		public string? LocationType { get; set; }
	}
}