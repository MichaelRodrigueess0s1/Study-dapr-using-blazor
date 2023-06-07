using Dapr.Client;
using DocBrown.Domain;
using DocBrown.Infra.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace DocBrown.App.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ForecastStateController : ControllerBase
	{
		ILogger<ForecastStateController> Logger { get; }
		DaprClient DaprClient { get; }
		IForecastRepository Repository { get; }

		public ForecastStateController(
			ILogger<ForecastStateController> logger, 
			DaprClient daprClient,
			IForecastRepository repository
			)
		{
			Logger = logger;
			DaprClient = daprClient;
			Repository = repository;
		}

		[HttpPost]
		public async Task<ActionResult<WeatherForecast>> Post(WeatherForecast forecast)
		{
			try
			{
				var updated = await Repository.Update(forecast);
				return Ok(updated);
			}
			catch (Exception e)
			{
				return Problem("Error", e.Message, 500, "Dapr Error");
			}
		}

		[HttpGet]
		public async Task<WeatherForecast> Get()
		{
			try
			{
				var state = await DaprClient.GetStateAsync<WeatherForecast>("stateStore", "AMS");
				return state;
			}
			catch (Exception)
			{
				return null;
			}
		}


	}
}
