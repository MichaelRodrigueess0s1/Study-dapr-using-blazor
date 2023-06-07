using Dapr.Client;
using DocBrown.Infra.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace DocBrown.App.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ForecastStateController : ControllerBase
	{
		ILogger<ForecastStateController> Logger { get; }
		IForecasts Repository { get; }

		public ForecastStateController(
			ILogger<ForecastStateController> logger,
			DaprClient daprClient,
			IForecasts repository
			)
		{
			Logger = logger;
			Repository = repository;
		}
	}
}
