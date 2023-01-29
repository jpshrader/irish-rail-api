using Microsoft.AspNetCore.Mvc;

namespace irish_rail_api.Common {
	public sealed class ApiVersion1 : ApiVersionAttribute {
		public const string VERSION = "1";

		public ApiVersion1() : base(VERSION) { }
	}
}