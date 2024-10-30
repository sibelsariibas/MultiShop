using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopCatalog.Dtos.ProductDetailDtos;
using MultiShopCatalog.Dtos.ProductDtos;
using MultiShopCatalog.Services.ProductDetailServices;
using MultiShopCatalog.Services.ProductServices;

namespace MultiShopCatalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductDetailsController : ControllerBase
	{
		private readonly IProductDetailServices _service;

		public ProductDetailsController(IProductDetailServices productDetailServices)
		{
			_service = productDetailServices;
		}

		[HttpGet]
		public async Task<IActionResult> List()
		{
			var values = await _service.GetAllAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(string id)
		{
			var values = await _service.GetByIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateProductDetailDto p)
		{
			await _service.CreateAsync(p);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(string id)
		{
			await _service.DeleteAsync(id);
			return Ok();
		}


		[HttpPut]
		public async Task<IActionResult> Update(UpdateProductDetailDto p)
		{
			await _service.UpdateAsync(p);
			return Ok();
		}
	}
}
