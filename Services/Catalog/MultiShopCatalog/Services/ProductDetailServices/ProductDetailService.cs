using AutoMapper;
using MongoDB.Driver;
using MultiShopCatalog.Dtos.ProductDetailDtos;
using MultiShopCatalog.Dtos.ProductImageDtos;
using MultiShopCatalog.Entities;
using MultiShopCatalog.Settings;

namespace MultiShopCatalog.Services.ProductDetailServices
{
	public class ProductDetailService : IProductDetailServices
	{
		private readonly IMongoCollection<ProductDetail> _collection;

		private readonly IMapper _mapper;

		public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var dataBase = client.GetDatabase(_databaseSettings.DatabaseName);
			_collection = dataBase.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
			_mapper = mapper;
		}

		public async Task CreateAsync(CreateProductDetailDto p)
		{
			var values = _mapper.Map<ProductDetail>(p);
			await _collection.InsertOneAsync(values);
		}

		public async Task DeleteAsync(string id)
		{
			await _collection.DeleteOneAsync(x => x.ProductDetailId == id);
		}

		public async Task<List<ResultProductDetailDto>> GetAllAsync()
		{
			var values = await _collection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductDetailDto>>(values);
		}

		public async Task<GetByProductDetailIdDto> GetByIdAsync(string id)
		{
			var value = await _collection.Find(x => x.ProductDetailId == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByProductDetailIdDto>(value);
		}

		public async Task UpdateAsync(UpdateProductDetailDto p)
		{
			var values = _mapper.Map<ProductDetail>(p);
			await _collection.FindOneAndReplaceAsync(x => x.ProductDetailId == p.ProductDetailId, values);
		}
	}
}
