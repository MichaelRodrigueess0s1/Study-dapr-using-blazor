using DocBrown.Domain.Abstractions;

namespace DocBrown.Domain.Entities
{
	public class BaseEntity : IBaseEntity
	{
		public long ID { get; set; }
		public string Key => ID.ToString();
		public string? Name { get; set; }
	}
}