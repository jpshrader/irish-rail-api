using irish_rail_api.Endpoints.TrainMovements.Models;

namespace irish_rail_api.Endpoints.TrainMovements.Adapters {
	public interface ITrainMovementAdapter {
		TrainMovementResource Adapt(TrainMovement trainMovement);
	}
}
