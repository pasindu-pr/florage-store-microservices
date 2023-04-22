using Florage.Payments.Dtos;
using Florage.Payments.Models;

namespace Florage.Payments.Contracts
{
    public interface IUserService
    {
        public Task<User> CreateUser(CreateUserDto createUserDto);
    }
}
