using MultiShopCatalog.Dtos.CategoryDtos;
using MultiShopCatalog.Dtos.ProductDtos;

namespace MultiShopCatalog.Services.ProductServices
{
	public interface IProductService
	{
		Task<List<ResultProductDto>> GetAllAsync();
		Task CreateAsync(CreateProductDto p);
		Task UpdateAsync(UpdateProductDto p);
		Task DeleteAsync(string id);
		Task<GetByIdProductIdDto> GetByIdAsync(string id);
	}
}
