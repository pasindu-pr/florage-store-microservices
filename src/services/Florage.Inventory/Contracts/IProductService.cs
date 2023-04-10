using Florage.Inventory.Dtos;

namespace Florage.Inventory.Contracts
{
    public interface IProductService
    {
        Task<GetProductDto> CreateAsync(CreateProductDto productDto);
        Task<IReadOnlyCollection<GetProductDto>> GetAllAsync();
        Task<GetProductDto> GetByIdAsync(string id);
        Task UpdateAsync(string productId, UpdateProductDto updateProductDto);
        Task DeleteAsync(string productId);
    }
}
