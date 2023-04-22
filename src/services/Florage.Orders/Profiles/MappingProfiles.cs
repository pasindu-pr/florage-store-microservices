using AutoMapper;
using Florage.Orders.Dtos;
using Florage.Orders.Models;
using Florage.Shared.Dtos.Orders;
using Florage.Shared.Dtos.Products;
using Florage.Shared.Dtos.Users;

namespace Florage.Orders.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        { 
            CreateMap<Order, GetOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<OrderProduct, OrderProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, PublishProductCreateDto>().ReverseMap();
            CreateMap<CreateProductDto, PublishProductCreateDto>().ReverseMap();
            CreateMap<UpdateProductDto, PublishProductUpdateDto>().ReverseMap();
            CreateMap<Order, PublishCreateOrderDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<CreateUserDto, PublishUserCreateDto>().ReverseMap();
        }
    }
}
