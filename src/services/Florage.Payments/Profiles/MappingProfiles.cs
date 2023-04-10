using AutoMapper;
using Florage.Payments.Dtos;
using Florage.Payments.Models;

namespace Florage.Payments.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateOrderDto, Order>().ReverseMap();
        }
    }
}
