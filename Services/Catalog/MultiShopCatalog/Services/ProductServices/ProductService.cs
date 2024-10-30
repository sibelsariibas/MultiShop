using AutoMapper;
using MongoDB.Driver;
using MultiShopCatalog.Dtos.CategoryDtos;
using MultiShopCatalog.Dtos.ProductDtos;
using MultiShopCatalog.Entities;
using MultiShopCatalog.Settings;

namespace MultiShopCatalog.Services.ProductServices
{
	public class ProductService : IProductService
	{

		private readonly IMongoCollection<Product> _collection;

		private readonly IMapper _mapper;

		public ProductService(IMapper mapper ,IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var dataBase = client.GetDatabase(_databaseSettings.DatabaseName);
			_collection = dataBase.GetCollection<Product>(_databaseSettings.ProductCollectionName);
			_mapper = mapper;
		}

		public async Task CreateAsync(CreateProductDto p)
		{
			var value = _mapper.Map<Product>(p);
			await _collection.InsertOneAsync(value);
		}

		public async Task DeleteAsync(string id)
		{
		await _collection.DeleteOneAsync(x => x.ProductId == id);
		}

		public async Task<List<ResultProductDto>> GetAllAsync()
		{
			var values = await _collection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductDto>>(values);
		}

		public async Task<GetByIdProductIdDto> GetByIdAsync(string id)
		{
			var value = await _collection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductIdDto>(value);
		}

		public async Task UpdateAsync(UpdateProductDto p)
		{
			var values = _mapper.Map<Product>(p);
			await _collection.FindOneAndReplaceAsync(x => x.ProductId == p.ProductId, values);
		}
	}
}
