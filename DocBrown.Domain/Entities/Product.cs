using DocBrown.Domain.Abstractions;

namespace DocBrown.Domain.Entities
{
	public class Product : BaseEntity, IProduct
	{
		public decimal Price { get; set; }
		public DateTime Date { get; set; }
	}
}