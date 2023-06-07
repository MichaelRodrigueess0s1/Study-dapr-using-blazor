using Dapr.Client;
using DocBrown.Domain.Abstractions;
using DocBrown.Infra.Abstractions.Repositories;
using Microsoft.Extensions.Logging;

namespace DocBrown.Infra.Repositories
{
	public class RedisBaseRepository<T> : IBaseRepository<T>
	where T : IBaseEntity
	{
		string StateStore;
		DaprClient Client;
		ILogger<RedisForecasters> Logger;

		string typeStore;

		public RedisBaseRepository(string stateStore, DaprClient client, ILogger<RedisForecasters> logger)
		{
			StateStore = stateStore;
			Client = client;
			Logger = logger;
			typeStore = typeof(T).Name;
		}

		public async Task<T> ByID(string keyId)
		{
			Logger.LogInformation($"{typeStore}-{keyId} get success");
			return await Client.GetStateAsync<T>(StateStore, $"{typeStore}-{keyId}");
		}

		public async Task Delete(string keyId)
		{
			await Client.DeleteStateAsync(StateStore, $"{typeStore}-{keyId}");
			Logger.LogInformation($"{typeStore}-{keyId} deleted success");
		}

		public async Task<T> Save(T entity)
		{
			await Client.SaveStateAsync<T>(StateStore, $"{typeStore}-{entity.Key}", entity);
			Logger.LogInformation($"{typeStore}-{entity.Key} saved success");
			return entity;
		}

		public async Task<T> Update(T entity)
		{
			try
			{
				var state = await Client.GetStateEntryAsync<T>(StateStore, $"{typeStore}-{entity.Key}");
				state.Value = entity;
				await state.SaveAsync();
				Logger.LogInformation($"{typeStore}-{entity.Key} updated success");
				return await ByID(entity.Key);
			}
			catch (Exception e)
			{
				Logger.LogError($"Error while Update {typeStore}-{entity.Key}", e);
				throw;
			}
		}
	}
}
