using irish_rail_api.Controllers.Trains.Models;

namespace irish_rail_api.Endpoints.Trains.Adapters {
	public interface ITrainAdapter {
		TrainResource Adapt(Train train, string apiVersion);
	}
}
