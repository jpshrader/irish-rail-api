using irish_rail_api.Common.Resources;
using irish_rail_api.Endpoints.TrainMovements.Models;

namespace irish_rail_api.Endpoints.TrainMovements.Services {
	public interface ITrainMovementService {
		ResourceList<TrainMovementResource> GetTrainMovements(string trainCode, string apiVersion);
	}
}
