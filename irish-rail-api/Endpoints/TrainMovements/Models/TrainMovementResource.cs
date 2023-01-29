using irish_rail_api.Common.Resources;

namespace irish_rail_api.Endpoints.TrainMovements.Models {
	public class TrainMovementResource : Resource {
		public string? TrainCode { get; set; }

		public string? TrainDate { get; set; }

		public string? LocationCode { get; set; }

		public string? LocationFullName { get; set; }

		public string? LocationOrder { get; set; }

		public string? LocationType { get; set; }

		public string? TrainOrigin { get; set; }

		public string? TrainDestination { get; set; }

		public string? ScheduledArrival { get; set; }

		public string? ScheduledDeparture { get; set; }

		public string? ExpectedArrival { get; set; }

		public string? ExpectedDeparture { get; set; }

		public string? Arrival { get; set; }

		public string? Departure { get; set; }

		public string? AutoArrival { get; set; }

		public string? AutoDepart { get; set; }

		public string? StopType { get; set; }
	}
}