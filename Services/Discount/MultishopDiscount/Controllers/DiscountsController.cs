using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultishopDiscount.Dtos;
using MultishopDiscount.Services;

namespace MultishopDiscount.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountsController : ControllerBase
	{
		private readonly IDiscountService _service;

		public DiscountsController(IDiscountService discountService)
		{
			_service = discountService;
		}

		[HttpGet]
		public async Task<IActionResult> List()
		{
			var values = await _service.GetAllAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _service.GetByIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateCouponDto p)
		{
			await _service.CreateAsync(p);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteAsync(id);
			return Ok();
		}


		[HttpPut]
		public async Task<IActionResult> Update(UpdateCouponDto p)
		{
			await _service.UpdateAsync(p);
			return Ok();
		}
	}
}
