using DocBrown.Domain.Abstractions;

namespace DocBrown.Infra.Abstractions.Repositories
{
	public interface IBaseRepository<T>
	where T : IBaseEntity
	{
		Task<T> ByID(string keyId);
		Task<T> Update(T entity);
		Task<T> Save(T entity);
		Task Delete(string keyId);
	}
}
