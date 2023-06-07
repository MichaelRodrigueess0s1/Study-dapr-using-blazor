
using Dapr.Client;
using DocBrown.Domain;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;


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
		public async Task<IEnumerable<WeatherForecast>> Get()
		{
			try
			{
				var forecasts = await daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(
						HttpMethod.Get,
						"forecast-service",
						"weatherforecast");

				return forecasts;
			}
			catch (Exception e)
			{
				return Enumerable.Empty<WeatherForecast>();
			}
		}
	}
}