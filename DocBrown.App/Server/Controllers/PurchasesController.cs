using DocBrown.Domain.Abstractions;
using DocBrown.Infra.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;
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
		public async Task<ActionResult> Get(string id)
		{
			var purchase = await Purchases.ByID(id);
			if (purchase.Equals(null))
				return NotFound("Purchase not Found");

			return Ok(purchase);
		}

		[HttpPost]
		[ProducesResponseType(typeof(IPurchase), (int)HttpStatusCode.OK)]
		[ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
		public async Task<ActionResult<IPurchase>> UpdateBasketAsync([FromBody] IPurchase purchase)
		{
			var saved = await Purchases.Update(purchase);
		}
	}
}
