using Dapper;
using MultishopDiscount.Context;
using MultishopDiscount.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MultishopDiscount.Services
{
	public class DiscountService : IDiscountService
	{
		private readonly DapperContext _context;

		public DiscountService( DapperContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(CreateCouponDto p)
		{
			string query = "insert into Coupons (Code , Rate , IsActive , ValidDate) values (@code , @rate , @isActive, @validDate)";
			var parameters = new DynamicParameters();
			parameters.Add("@code", p.Code);
			parameters.Add("@rate", p.Rate);
			parameters.Add("@isActive", p.IsActive);
			parameters.Add("@validDate",p.ValidDate);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task DeleteAsync(int id)
		{
			string query = "Delete From Coupons Where CouponId=@CouponId";
			var parameters = new DynamicParameters();
			parameters.Add("@CouponId", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultCouponDto>> GetAllAsync()
		{
			string query = "Select * From Coupons";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultCouponDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByCouponIdDto> GetByIdAsync(int id)
		{
			string query = "Select * From Coupons Where CouponId=@CouponId";
			var parameters = new DynamicParameters();
			parameters.Add("@CouponId", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByCouponIdDto>(query,parameters);
				return values;
			}

		}

		public async Task UpdateAsync(UpdateCouponDto p)
		{
			string query = "Update Coupons Set Code=@code , Rate=@rate , IsActive=@isactive, ValidDate=@validDate Where CouponId=@CouponId ";
			var parameters = new DynamicParameters();
			parameters.Add("@CouponId", p.CouponId);
			parameters.Add("@code", p.Code);
			parameters.Add("@rate", p.Rate);
			parameters.Add("@isActive", p.IsActive);
			parameters.Add("@validDate", p.ValidDate);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
