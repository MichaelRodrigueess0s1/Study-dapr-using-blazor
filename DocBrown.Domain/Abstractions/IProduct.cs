namespace DocBrown.Domain.Abstractions
{
	public interface IProduct : IBaseEntity
	{
		DateTime Date { get; set; }
		decimal Price { get; set; }
	}
}