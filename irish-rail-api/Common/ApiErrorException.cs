using System.Net;

namespace irish_rail_api.Common {
	// Todo: Refactor to service error pattern
	public class ApiError : Exception {
		public HttpStatusCode StatusCode { get; set; }

		public ApiError(HttpStatusCode statusCode, string message) : base(message) {
			StatusCode = statusCode;
		}
	}
}
