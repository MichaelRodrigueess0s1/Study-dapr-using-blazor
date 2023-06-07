using DocBrown.Domain.Abstractions;

namespace DocBrown.Domain
{
	public class PurchaseItem : BaseEntity, IPurchaseItem
	{
		public decimal Value { get; }
		public IProduct Product { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public DateTime Purchase { get; set; }
	}
}