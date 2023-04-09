using AutoMapper;
using Florage.Orders.Contracts;
using Florage.Orders.Dtos;
using Florage.Orders.Models;
using Florage.Orders.Utils;
using Florage.Shared.Contracts;

namespace Florage.Orders.Services
{
    public class ProductsService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductsService(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _repository.SetCollectionName(Constants.ProductsCollectionName);
            _mapper = mapper;
        } 

        public async Task<GetProductDto> CreateAsync(CreateProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
             
            Product insertedProduct = await _repository.CreateAsync(product);
            GetProductDto getProductDto = _mapper.Map<GetProductDto>(insertedProduct);
            return getProductDto;
        }

        public async Task DeleteAsync(string productId)
        {
            await _repository.DeleteAsync(productId);
        }

        public async Task<IReadOnlyCollection<GetProductDto>> GetAllAsync()
        {
            IReadOnlyCollection<Product> products = await _repository.GetAllAsync();
            IReadOnlyCollection<GetProductDto> getProducts = _mapper.Map<IReadOnlyCollection<GetProductDto>>(products);
            return getProducts;
        }

        public async Task UpdateAsync(string productId, UpdateProductDto updateProductDto)
        {
            Product productToUpdate = _mapper.Map<Product>(updateProductDto);

            productToUpdate.Id = productId;
            await _repository.UpdateAsync(productId, productToUpdate);
        }
    }
}
