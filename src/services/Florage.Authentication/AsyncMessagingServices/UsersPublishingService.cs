using AutoMapper;
using Florage.Authentication.Contracts;
using Florage.Authentication.Dtos;
using Florage.Shared.Dtos.Users;
using MassTransit;

namespace Florage.Authentication.AsyncMessagingServices
{
    public class UsersPublishingService : IUsersPublishingService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public UsersPublishingService(IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }
        public async void PublishUserCreate(UserPublishDto user)
        {
            PublishUserCreateDto userToPublish = _mapper.Map<PublishUserCreateDto>(user);
            await _publishEndpoint.Publish(userToPublish);
        }
    }
}
