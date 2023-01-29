using irish_rail_api.Endpoints.TrainMovements.Models;

namespace irish_rail_api.Endpoints.TrainMovements.Data {
	public interface ITrainMovementRetriever {
		IEnumerable<TrainMovement> GetTrainMovements(string trainCode);
	}
}