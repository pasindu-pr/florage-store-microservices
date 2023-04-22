using AutoMapper;
using Florage.Payments.Contracts;
using Florage.Payments.Dtos;
using Florage.Shared.Dtos.Users;
using MassTransit;

namespace Florage.Payments.AsyncServices.Consumers
{
    public class UserCreateConsumer : IConsumer<PublishUserCreateDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserCreateConsumer(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<PublishUserCreateDto> context)
        {
            CreateUserDto createUserDto = _mapper.Map<CreateUserDto>(context.Message);
            await _userService.CreateUser(createUserDto);
        }
    }
}
