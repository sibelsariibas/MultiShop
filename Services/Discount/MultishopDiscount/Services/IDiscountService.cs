using MultishopDiscount.Dtos;

namespace MultishopDiscount.Services
{
	public interface IDiscountService
	{
		Task<List<ResultCouponDto>> GetAllAsync();
		Task CreateAsync(CreateCouponDto p);
		Task UpdateAsync(UpdateCouponDto p);
		Task DeleteAsync(int id);
		Task<GetByCouponIdDto> GetByIdAsync(int id);
	}
}
