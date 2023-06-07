using Dapr.Client.Autogen.Grpc.v1;
using DocBrown.Domain;

namespace DocBrown.Infra.Abstractions.Repositories
{
	public interface IForecastRepository
	{
		Task<WeatherForecast> ByID(string keyId);
		Task<WeatherForecast> Update(WeatherForecast weatherForecast);
		Task Delete(string keyId);
		Task<IEnumerable<WeatherForecast>> All();
	}
}
