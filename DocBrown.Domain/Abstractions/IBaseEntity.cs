namespace DocBrown.Domain.Abstractions
{
	public interface IBaseEntity
	{
		long ID { get; set; }
		string Name { get; }
		string Key { get; }
	}
}