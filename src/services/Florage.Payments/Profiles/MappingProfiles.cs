using AutoMapper;
using Florage.Payments.Dtos;
using Florage.Payments.Models;
using Florage.Shared.Dtos.Orders;

namespace Florage.Payments.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<Order, GetOrderDto>().ReverseMap();
            CreateMap<CreateOrderDto, PublishCreateOrderDto>().ReverseMap();
        }
    }
}
