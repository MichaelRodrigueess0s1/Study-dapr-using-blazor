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

		public RedisBaseRepository(string stateStore, DaprClient client, ILogger<RedisForecasters> logger)
		{
			StateStore = stateStore;
			Client = client;
			Logger = logger;
		}

		public async Task<T> ByID(string keyId)
		{
			return await Client.GetStateAsync<T>(StateStore, keyId);
		}

		public async Task Delete(string keyId)
		{
			await Client.DeleteStateAsync(StateStore, keyId);
		}
		public async Task<T> Update(T entity)
		{
			try
			{
				var state = await Client.GetStateEntryAsync<T>(StateStore, entity.Key);
				state.Value = entity;
				await state.SaveAsync();
				Logger.LogInformation("T entity item persisted successfully.");
				return await ByID(entity.Key);
			}
			catch (Exception e)
			{
				throw;
			}
		}
	}
}
