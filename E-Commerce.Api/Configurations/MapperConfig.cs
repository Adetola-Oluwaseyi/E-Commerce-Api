using AutoMapper;
using E_Commerce.Api.Data;
using E_Commerce.Api.Models.Products;

namespace E_Commerce.Api.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, GetProductsDto>();
            CreateMap<Product, GetProductDto>()
                .ForMember(
                dest => dest.CategoryName,
                u => u.MapFrom(src => src.Category != null ? src.Category.Name : null));

        }
    }
}
