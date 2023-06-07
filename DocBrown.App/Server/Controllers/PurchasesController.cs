using DocBrown.App.Server.Validators;
using DocBrown.Domain.Abstractions;
using DocBrown.Domain.Validators;
using DocBrown.Infra.Abstractions.Repositories;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace DocBrown.App.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PurchasesController : ControllerBase
	{
		ILogger<PurchasesController> Logger { get; }
		IPurchases Purchases { get; }

		public PurchasesController(IPurchases purchases)
		{
			Purchases = purchases;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(IPurchase), (int)HttpStatusCode.OK)]
		[ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
		public async Task<ActionResult> GetAsync(string id)
		{
			var purchase = await Purchases.ByID(id);
			if (purchase == null)
				return NotFound("Purchase not Found");

			return Ok(purchase);
		}

		[HttpPost]
		[ProducesResponseType(typeof(IPurchase), (int)HttpStatusCode.OK)]
		[ProducesResponseType(typeof(ValidationProblem), (int)HttpStatusCode.BadRequest)]
		public async Task<ActionResult<IPurchase>> PostAsync(Validated<IPurchase> toValidate)
		{
			var (isValid, purchase) = toValidate;
			var erros = toValidate.Errors;
			return isValid ? Ok(toValidate) : ValidationProblem(detail: "Validator problems", instance: $"{purchase.Name}");
		}
	}
}
