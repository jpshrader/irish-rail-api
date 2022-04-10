using irish_rail_api.Common.Resources;

namespace irish_rail_api.Controllers.Trains.Models {
	public class TrainResource : Resource {
		public string? Code { get; set; }

		public string? Status { get; set; }

		public string? Latitude { get; set; }

		public string? Longitude { get; set; }

		public string? Date { get; set; }

		public string? Origin { get; set; }

		public string? Destination { get; set; }

		public string? Message { get; set; }

		public string? Direction { get; set; }

		public int MinutesLate { get; set; }
	}
}
