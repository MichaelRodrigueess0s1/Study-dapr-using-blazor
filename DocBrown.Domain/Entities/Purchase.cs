using DocBrown.Domain.Abstractions;

namespace DocBrown.Domain.Entities
{
	public class Purchase : BaseEntity, IPurchase
	{
		public Purchase()
		{
			Items = new List<IPurchaseItem>() { new PurchaseItem() { ID = 1, Name = "Teste", Product = new Product() { ID = 1, Name = "Jogo" } };
		}
		public Purchase(ICustomer customer, IEnumerable<IPurchaseItem> items)
		{
			Customer = customer;
			Items = items;
			Date = DateTime.Now;
		}

		public ICustomer? Customer { get; set; }
		public DateTime Date { get; set; }
		public IEnumerable<IPurchaseItem>? Items { get; set; }
	}
}