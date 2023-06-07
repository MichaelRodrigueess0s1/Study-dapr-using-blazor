
using Dapr.Client;
using DocBrown.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DocBrown.App.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly DaprClient daprClient;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, DaprClient daprClient)
		{
			_logger = logger;
			this.daprClient = daprClient;
		}

		[HttpGet]
		public async Task<IEnumerable<IForecast>> Get()
		{
			var forecasts = Enumerable.Empty<IForecast>();
			try
			{
				forecasts = await daprClient.GetStateAsync<IEnumerable<IForecast>>("statestore", "forecasters");

				


			}
			catch (Exception e)
			{
				//
			}
			return forecasts;
		}
	}
}