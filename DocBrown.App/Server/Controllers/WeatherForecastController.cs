
using Dapr.Client;
using DocBrown.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using DocBrown.Domain.Extensions;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using DocBrown.Domain.Abstractions;

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
			var result = Enumerable.Empty<Dictionary<string, object>>();
			try
			{
				//result = await daprClient.GetStateAsync<IEnumerable<ExpandoObject>>("statestore", "forecasters");
				result = await daprClient.InvokeMethodAsync<IEnumerable<Dictionary<string, object>>>(
					   HttpMethod.Get,
					   "forecast-service",
				"weatherforecast");

				var configuration = new MapperConfiguration(cfg => {
					cfg.CreateMap<WeatherForecast, Dictionary<string, object>>();
				});
				var mapper = configuration.CreateMapper();

				forecasts = result.Select(x => x.Map<WeatherForecast>(mapper)).ToList();

				await daprClient.SaveStateAsync("statestore", "forecasters", forecasts);
			}
			catch (Exception e)
			{
				//
			}
			return forecasts;
		}
	}
}