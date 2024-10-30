using AutoMapper;
using MongoDB.Driver;
using MultiShopCatalog.Dtos.CategoryDtos;
using MultiShopCatalog.Entities;
using MultiShopCatalog.Settings;
using System.Collections.Generic;

namespace MultiShopCatalog.Services.CategoryServices
{
	public class CategoryService : ICategoryService
	{

		private readonly IMongoCollection<Category> _collection;

		private readonly IMapper _mapper;

		public CategoryService(IMapper mapper , IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var dataBase = client.GetDatabase(_databaseSettings.DatabaseName);
			_collection = dataBase.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
			_mapper = mapper;
		}

		public async Task CreateAsync(CreateCategoryDto p)
		{
			var value = _mapper.Map<Category>(p);
			await _collection.InsertOneAsync(value);
		}

		public async Task DeleteAsync(string id)
		{
			await _collection.DeleteOneAsync(x=>x.CategoryId == id);
		}

		public async Task<List<ResultCategoryDto>> GetAllAsync()
		{
			var values = await _collection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultCategoryDto>>(values);
		}

		public async Task<GetByIdCategoryDto> GetByIdAsync(string id)
		{
			var value = await _collection.Find(x=>x.CategoryId==id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdCategoryDto>(value);
		}

		public async Task UpdateAsync(UpdateCategoryDto p)
		{
			var values = _mapper.Map<Category>(p);
			await _collection.FindOneAndReplaceAsync(x=>x.CategoryId==p.CategoryId,values);
		}
	}
}
