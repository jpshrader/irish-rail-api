using irish_rail_api.Common.Access;
using irish_rail_api.Controllers.Trains.Models;

namespace irish_rail_api.Trains.Data {
	public class TrainsRetriever : ITrainsRetriever {
		private const string GET_CURRENT_TRAINS_URL = "http://api.irishrail.ie/realtime/realtime.asmx/getCurrentTrainsXML";

		private readonly IApiAccess<Train> apiAccess;

		public TrainsRetriever(IApiAccess<Train> apiAccess) {
			this.apiAccess = apiAccess;
		}

		public IEnumerable<Train> GetTrains() {
			return apiAccess.GetResources(new Uri(GET_CURRENT_TRAINS_URL));
		}
	}
}