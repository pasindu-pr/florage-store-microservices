using Florage.Orders.Dtos;
using Florage.Orders.Models;

namespace Florage.Orders.Contracts
{
    public interface IUserService
    {
        public Task<User> CreateUser(CreateUserDto createUserDto);
    }
}
