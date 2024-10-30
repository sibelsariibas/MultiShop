using MultiShopCatalog.Dtos.ProductDetailDtos;

namespace MultiShopCatalog.Services.ProductDetailServices
{
	public interface IProductDetailServices
	{
		Task<List<ResultProductDetailDto>> GetAllAsync();
		Task CreateAsync(CreateProductDetailDto p);
		Task UpdateAsync(UpdateProductDetailDto p);
		Task DeleteAsync(string id);
		Task<GetByProductDetailIdDto> GetByIdAsync(string id);
	}
}
