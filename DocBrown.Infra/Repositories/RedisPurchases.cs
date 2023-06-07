using Dapr.Client;
using DocBrown.Domain.Abstractions;
using DocBrown.Infra.Abstractions.Repositories;
using Microsoft.Extensions.Logging;

namespace DocBrown.Infra.Repositories
{
	public class RedisPurchases : RedisBaseRepository<IPurchase>, IPurchases
	{
		public RedisPurchases(DaprClient client, ILogger<RedisForecasters> logger) : base("statestore", client, logger)
		{
		}
	}
}
