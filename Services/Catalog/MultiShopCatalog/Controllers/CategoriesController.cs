using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopCatalog.Dtos.CategoryDtos;
using MultiShopCatalog.Services.CategoryServices;

namespace MultiShopCatalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _service;

		public CategoriesController(ICategoryService categoryService)
		{
			_service = categoryService;
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
		public async Task<IActionResult> Create(CreateCategoryDto p )
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
		public async Task<IActionResult> Update(UpdateCategoryDto p)
		{
			await _service.UpdateAsync(p);
			return Ok();
		}
	}
}
