using DocBrown.Domain.Abstractions;

namespace DocBrown.Domain
{
	public class Product : BaseEntity, IProduct
	{
		public decimal Price { get; set; }
		public DateTime Date { get; set; }
	}
}