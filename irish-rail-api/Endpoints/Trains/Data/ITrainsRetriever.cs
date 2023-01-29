using irish_rail_api.Controllers.Trains.Models;

namespace irish_rail_api.Trains.Data {
	public interface ITrainsRetriever {
		IEnumerable<Train> GetTrains();
	}
}