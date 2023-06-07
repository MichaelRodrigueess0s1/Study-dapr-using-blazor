using Dapr.Client;
using DocBrown.Domain.Abstractions;
using DocBrown.Infra.Abstractions.Repositories;
using Microsoft.Extensions.Logging;

namespace DocBrown.Infra.Repositories
{
	public class RedisForecasters : RedisBaseRepository<IForecast>, IForecasts
	{
		public RedisForecasters(DaprClient client, ILogger<RedisForecasters> logger) : base("statestore", client, logger)
		{
		}
	}
}
