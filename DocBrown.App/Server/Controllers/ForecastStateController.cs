using Dapr.Client;
using DocBrown.Domain;
using Microsoft.AspNetCore.Mvc;


namespace DocBrown.App.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ForecastStateController : ControllerBase
	{
		public ILogger<ForecastStateController> Logger { get; }
		public DaprClient DaprClient { get; }

		public ForecastStateController(ILogger<ForecastStateController> logger, DaprClient daprClient)
		{
			Logger = logger;
			DaprClient = daprClient;
		}

		[HttpPost]
		public async Task<ActionResult<WeatherForecast>> Post(WeatherForecast forecast)
		{
			try
			{
				
				await DaprClient.SaveStateAsync("stateStore", "AMS", forecast);
			}
			catch (Exception e)
			{
				return Problem("Error", e.Message, 500, "Dapr Error");
			}
			return Ok(forecast);
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
