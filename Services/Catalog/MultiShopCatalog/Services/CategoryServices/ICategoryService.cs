using MultiShopCatalog.Dtos.CategoryDtos;

namespace MultiShopCatalog.Services.CategoryServices
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDto>> GetAllAsync();
		Task  CreateAsync(CreateCategoryDto p);
		Task UpdateAsync(UpdateCategoryDto p);
		Task DeleteAsync(string id);
		Task<GetByIdCategoryDto> GetByIdAsync(string id);
	}
}
