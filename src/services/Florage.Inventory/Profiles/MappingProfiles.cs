using AutoMapper;
using Florage.Inventory.Dtos;
using Florage.Inventory.Models;
using Florage.Shared.Dtos.Products;

namespace Florage.Inventory.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, PublishProductCreateDto>().ReverseMap();
            CreateMap<Product, PublishProductUpdateDto>().ReverseMap();
        }
    }
}