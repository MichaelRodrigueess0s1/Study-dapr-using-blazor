namespace DocBrown.Domain.Abstractions
{
	public interface IPurchaseItem : IBaseEntity
	{
		IProduct Product { get; set; }
		DateTime Purchase { get; set; }
		int Quantity { get; set; }
		decimal UnitPrice { get; set; }
		decimal Value { get; }
	}
}