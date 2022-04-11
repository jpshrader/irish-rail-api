using irish_rail_api.Common.Access;
using irish_rail_api.Common.Access.RequestStore;
using irish_rail_api.Controllers.Trains.Models;
using irish_rail_api.Endpoints.StationDetails.Adapters;
using irish_rail_api.Endpoints.StationDetails.Data;
using irish_rail_api.Endpoints.StationDetails.Models;
using irish_rail_api.Endpoints.StationDetails.Services;
using irish_rail_api.Endpoints.Stations.Adapters;
using irish_rail_api.Endpoints.Stations.Data;
using irish_rail_api.Endpoints.Stations.Services;
using irish_rail_api.Endpoints.TrainMovements.Adapters;
using irish_rail_api.Endpoints.TrainMovements.Data;
using irish_rail_api.Endpoints.TrainMovements.Models;
using irish_rail_api.Endpoints.TrainMovements.Services;
using irish_rail_api.Endpoints.Trains.Adapters;
using irish_rail_api.Endpoints.Trains.Services;
using irish_rail_api.Models;
using irish_rail_api.Trains.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddApiVersioning((config) => {
	config.DefaultApiVersion = new ApiVersion(1, 0);
	config.AssumeDefaultVersionWhenUnspecified = true;
	config.ReportApiVersions = true;
});

builder.Services.AddSwaggerGen(c => {
	c.SwaggerDoc("v1", new() {
		Title = "Irish Rail Api",
		Description = "REST Api for pulling various pieces of information from the Irish Realtime Rail Api",
		Version = "v1"
	});
});

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder => {
	builder.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader();
}));

// Add DI singletons
builder.Services
	.AddSingleton<IStationDetailsService, StationDetailsService>()
	.AddSingleton<IStationDetailsRetriever, StationDetailsRetriever>()
	.AddSingleton<IStationDetailsAdapter, StationDetailsAdapter>()
	.AddSingleton<IApiAccess<StationDetail>, ApiAccess<StationDetail>>()

	.AddSingleton<IStationsService, StationsService>()
	.AddSingleton<IStationRetriever, StationRetriever>()
	.AddSingleton<IStationAdapter, StationAdapter>()
	.AddSingleton<IApiAccess<Station>, ApiAccess<Station>>()

	.AddSingleton<ITrainMovementService, TrainMovementService>()
	.AddSingleton<ITrainMovementRetriever, TrainMovementRetriever>()
	.AddSingleton<ITrainMovementAdapter, TrainMovementAdapter>()
	.AddSingleton<IApiAccess<TrainMovement>, ApiAccess<TrainMovement>>()

	.AddSingleton<ITrainsService, TrainsService>()
	.AddSingleton<ITrainsRetriever, TrainsRetriever>()
	.AddSingleton<ITrainAdapter, TrainAdapter>()
	.AddSingleton<IApiAccess<Train>, ApiAccess<Train>>();

var app = builder.Build();
var isDev = app.Environment.IsDevelopment();
if (isDev)
	app.UseDeveloperExceptionPage();

// Add Swagger
var swaggerUrlPrefix = isDev ? string.Empty : "/rail-api";
app.UseSwagger();
app.UseSwaggerUI(c => {
	c.RoutePrefix = "swagger";
	c.SwaggerEndpoint($"{swaggerUrlPrefix}/swagger/v1/swagger.json", "Irish Rail Api");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var cacheConfig = app.Configuration.GetSection("Caching");
ApiRequestStoreSession.IsEnabled = cacheConfig.GetValue<bool>(nameof(ApiRequestStoreSession.IsEnabled));
ApiRequestStoreSession.RetentionPolicy = cacheConfig.GetValue<int>(nameof(ApiRequestStoreSession.RetentionPolicy));

app.Run();
