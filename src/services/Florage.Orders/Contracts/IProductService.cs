using Florage.Orders.Dtos;

namespace Florage.Orders.Contracts
{
    public interface IProductService
    {
        Task<IReadOnlyCollection<GetProductDto>> GetAllAsync();
        Task<GetProductDto> CreateAsync(CreateProductDto productDto);
    }
}
