using DocBrown.Domain.Abstractions;
using FluentValidation;

namespace DocBrown.Domain.Validators
{
	public class PurchaseValidator : AbstractValidator<IPurchase>
	{
		public PurchaseValidator()
		{
			RuleFor(p => p.Date).GreaterThan(DateTime.Now.AddDays(-1));
			RuleFor(p => p.Customer).NotNull();
		}
	}
}
