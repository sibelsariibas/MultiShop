using MultiShopCatalog.Dtos.ProductImageDtos;

namespace MultiShopCatalog.Services.ProductImageServices
{
	public interface IProductImageService
	{
		Task<List<ResultProductImageDto>> GetAllAsync();
		Task CreateAsync(CreateProductImageDto p);
		Task UpdateAsync(UpdateProductImageDto p);
		Task DeleteAsync(string id);
		Task<GetByProductImageIdDto> GetByIdAsync(string id);
	}
}
