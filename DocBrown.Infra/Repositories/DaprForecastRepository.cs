using Dapr.Client;
using DocBrown.Domain;
using DocBrown.Infra.Abstractions.Repositories;
using Microsoft.Extensions.Logging;

namespace DocBrown.Infra.Repositories
{
	public class DaprForecastRepository : IForecastRepository
	{
		DaprClient Client { get; }
		ILogger<DaprForecastRepository> Logger;
		private const string StateStore = "statestore";

		public DaprForecastRepository(DaprClient client, ILogger<DaprForecastRepository> logger)
		{
			Client = client;
			Logger = logger;
		}

		public Task<IEnumerable<WeatherForecast>> All()
		{
			throw new NotImplementedException("não sei implementar");
		}

		public Task<WeatherForecast> ByID(string keyId)
		{
			var state =  Client.GetStateAsync<WeatherForecast>(StateStore, keyId);
			return state;
		}

		public async Task Delete(string keyId)
		{
			await Client.DeleteStateAsync(StateStore, keyId);
		}

		public async Task<WeatherForecast> Update(WeatherForecast weatherForecast)
		{
			try
			{
				var state = await Client.GetStateEntryAsync<WeatherForecast>(StateStore, weatherForecast.KeyID);
				state.Value = weatherForecast;

				await state.SaveAsync();

				Logger.LogInformation("WeatherForecast item persisted successfully.");

				return await ByID(weatherForecast.KeyID);
			}
			catch (Exception e)
			{
				throw;
			}
		}
	}
}
