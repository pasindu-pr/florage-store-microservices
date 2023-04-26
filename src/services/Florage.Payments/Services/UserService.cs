using AutoMapper;
using Florage.Payments.Contracts;
using Florage.Payments.Dtos;
using Florage.Payments.Models;
using Florage.Payments.Utils;
using Florage.Shared.Contracts;

namespace Florage.Payments.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _repository.SetCollectionName(Constants.UsersCollectionName);
        }
        public async Task<User> CreateUser(CreateUserDto createUserDto)
        {
            User user = _mapper.Map<User>(createUserDto);
            User insertedUser = await _repository.CreateAsync(user);
            return insertedUser;
        }

        public async Task<User> GetUserById(string userId)
        {             
            User user = await _repository.GetByIdAsync(userId);
            return user;
        }
    }
}
