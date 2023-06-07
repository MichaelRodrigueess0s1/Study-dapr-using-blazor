using DocBrown.Domain.Abstractions;

namespace DocBrown.Domain
{
	public class Purchase : BaseEntity, IPurchase
	{
		public ICustomer? Customer { get; set; }
		public DateTime Date { get; set; }
		public IEnumerable<IPurchaseItem>? Items { get; set; }
	}
}