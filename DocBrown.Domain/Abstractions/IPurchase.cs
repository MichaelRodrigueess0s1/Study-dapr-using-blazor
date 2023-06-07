namespace DocBrown.Domain.Abstractions
{
	public interface IPurchase : IBaseEntity
	{
		ICustomer Customer { get; set; }
		DateTime Date { get; set; }
		IEnumerable<IPurchaseItem> Items { get; set; }
	}
}