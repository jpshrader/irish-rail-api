using irish_rail_api.Common.Resources;
using irish_rail_api.Controllers.Trains.Models;

namespace irish_rail_api.Endpoints.Trains.Services {
	public interface ITrainsService {
		ResourceList<TrainResource> GetTrains(string apiVersion);

		TrainResource? GetTrain(string trainCode, string apiVersion);
	}
}
