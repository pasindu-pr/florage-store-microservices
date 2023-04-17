using AutoMapper;
using Florage.Products.Dtos;
using Florage.Products.Models;

namespace Florage.Products.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<CreateProductDto, PublishProductDto>().ReverseMap();
        }
    }
}
