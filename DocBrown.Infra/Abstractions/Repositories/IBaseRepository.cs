using DocBrown.Domain.Abstractions;

namespace DocBrown.Infra.Abstractions.Repositories
{
	public interface IBaseRepository<T>
	where T : IBaseEntity
	{
		Task<T> ByID(string keyId);
		Task<T> Update(T weatherForecast);
		Task Delete(string keyId);
	}
}
