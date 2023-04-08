using AutoMapper;
using Florage.Products.Contracts;
using Florage.Products.Dtos;
using Florage.Products.Models;
using Florage.Shared.Contracts;

namespace Florage.Products.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        private readonly string _customIdentifierAttribute = "ProductId";

        public ProductsService(IRepository<Product> genericRepository, IMapper mapper)
        {
            _repository = genericRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);

            // Generate custom product id
            product.ProductId = Guid.NewGuid().ToString();
            await _repository.CreateAsync(product);
        }

        public async Task DeleteAsync(string productId)
        {
            await _repository.DeleteAsync(_customIdentifierAttribute, productId);
        }

        public async Task<IReadOnlyCollection<GetProductDto>> GetAllAsync()
        {
            IReadOnlyCollection<Product> products = await _repository.GetAllAsync();
            IReadOnlyCollection<GetProductDto> mappedProducts = _mapper.Map<IReadOnlyCollection<GetProductDto>>(products);
            return mappedProducts;
        }

        public async Task<GetProductDto> GetByIdAsync(string id)
        {
            // Get product by custom product id
            Product product = await _repository.GetOneAsync(_customIdentifierAttribute, id);
            GetProductDto mappedProduct = _mapper.Map<GetProductDto>(product);
            return mappedProduct;
        }

        public async Task UpdateAsync(string productId,UpdateProductDto updateProductDto)
        {
            Product productToUpdate = _mapper.Map<Product>(updateProductDto);
            Product product = await _repository.GetOneAsync(_customIdentifierAttribute, productId);
            
            productToUpdate.Id = product.Id;
            productToUpdate.ProductId = productId;
            await _repository.UpdateAsync(_customIdentifierAttribute, productId,productToUpdate);
        }
    }
}
