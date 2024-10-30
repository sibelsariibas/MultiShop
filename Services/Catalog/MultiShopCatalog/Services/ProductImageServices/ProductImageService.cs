using AutoMapper;
using MongoDB.Driver;
using MultiShopCatalog.Dtos.ProductDtos;
using MultiShopCatalog.Dtos.ProductImageDtos;
using MultiShopCatalog.Entities;
using MultiShopCatalog.Settings;

namespace MultiShopCatalog.Services.ProductImageServices
{


	public class ProductImageService : IProductImageService
	{
		private readonly IMongoCollection<ProductImage> _collection;

		private readonly IMapper _mapper;

		public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var dataBase = client.GetDatabase(_databaseSettings.DatabaseName);
			_collection = dataBase.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
			_mapper = mapper;
		}

		public async Task CreateAsync(CreateProductImageDto p)
		{
		var values = _mapper.Map<ProductImage>(p);
		await _collection.InsertOneAsync(values);
		}

		public async Task DeleteAsync(string id)
		{
			await _collection.DeleteOneAsync(x => x.ProductImageId == id);
		}

		public async  Task<List<ResultProductImageDto>> GetAllAsync()
		{
			var values = await _collection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductImageDto>>(values);
		}

		public async Task<GetByProductImageIdDto> GetByIdAsync(string id)
		{
			var value = await _collection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByProductImageIdDto>(value);
		}

		public async Task UpdateAsync(UpdateProductImageDto p)
		{
			var values = _mapper.Map<ProductImage>(p);
			await _collection.FindOneAndReplaceAsync(x => x.ProductImageId == p.ProductImageId, values);
		}
	}
}
