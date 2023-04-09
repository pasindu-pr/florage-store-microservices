using Florage.Orders.Dtos;

namespace Florage.Orders.Contracts
{
    public interface IProductService
    {
        Task<IReadOnlyCollection<GetProductDto>> GetAllAsync();
        Task<GetProductDto> CreateAsync(CreateProductDto productDto);
        Task UpdateAsync(string productId, UpdateProductDto updateProductDto);
        Task DeleteAsync(string productId);
    }
}
