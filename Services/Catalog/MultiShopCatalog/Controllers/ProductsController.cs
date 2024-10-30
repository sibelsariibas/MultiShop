using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopCatalog.Dtos.CategoryDtos;
using MultiShopCatalog.Dtos.ProductDtos;
using MultiShopCatalog.Services.CategoryServices;
using MultiShopCatalog.Services.ProductServices;

namespace MultiShopCatalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _service;

		public ProductsController(IProductService productService)
		{
			_service = productService;
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
		public async Task<IActionResult> Create(CreateProductDto p)
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
		public async Task<IActionResult> Update(UpdateProductDto p)
		{
			await _service.UpdateAsync(p);
			return Ok();
		}
	}
}
