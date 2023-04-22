using AutoMapper;
using Florage.Authentication.Dtos;
using Florage.Shared.Dtos.Users;

namespace Florage.Authentication.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<PublishUserCreateDto, UserPublishDto>().ReverseMap();
        }
    }
}
