using Florage.Products.Dtos;
using Florage.Products.Models;

namespace Florage.Products.Contracts
{
    public interface IProductsService
    {
        Task CreateAsync(CreateProductDto productDto);
        Task<IReadOnlyCollection<GetProductDto>> GetAllAsync();
        Task<GetProductDto> GetByIdAsync(string id);
    }
}
