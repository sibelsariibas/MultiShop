using AutoMapper;
using MultiShopCatalog.Dtos.CategoryDtos;
using MultiShopCatalog.Dtos.ProductDetailDtos;
using MultiShopCatalog.Dtos.ProductDtos;
using MultiShopCatalog.Dtos.ProductImageDtos;
using MultiShopCatalog.Entities;

namespace MultiShopCatalog.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping()
		{
		CreateMap<Category , ResultCategoryDto>().ReverseMap();
		CreateMap<Category, CreateCategoryDto>().ReverseMap();
		CreateMap<Category, UpdateCategoryDto>().ReverseMap();
		CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

		CreateMap<Product, ResultProductDto>().ReverseMap();
		CreateMap<Product, UpdateProductDto>().ReverseMap();
		CreateMap<Product, CreateProductDto>().ReverseMap();
		CreateMap<Product, GetByIdProductIdDto>().ReverseMap();

		CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
		CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
		CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
		CreateMap<ProductDetail, GetByProductDetailIdDto>().ReverseMap();

	    CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
	    CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
	    CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
	    CreateMap<ProductImage, GetByProductImageIdDto>().ReverseMap();
		}
	}
}
