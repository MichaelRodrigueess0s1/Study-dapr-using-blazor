
using Dapr.Client;
using DocBrown.Domain;
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
		public async Task<IEnumerable<WeatherForecast>> Get()
		{
			try
			{
				var forecasts = await daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(
						HttpMethod.Get,
						"docbrownforecasterapi",
						"weatherforecast");

				return forecasts;
			}
			catch (Exception)
			{
				return Enumerable.Empty<WeatherForecast>();
			}
		}
	}
}