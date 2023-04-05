using Florage.Products.Dtos; 

namespace Florage.Products.Contracts
{
    public interface IProductsService
    {
        Task CreateAsync(CreateProductDto productDto);
        Task<IReadOnlyCollection<GetProductDto>> GetAllAsync();
        Task<GetProductDto> GetByIdAsync(string id);
        Task UpdateAsync(string productId, UpdateProductDto updateProductDto);
        Task DeleteAsync(string productId);
    }
}
