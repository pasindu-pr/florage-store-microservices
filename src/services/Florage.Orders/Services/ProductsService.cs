using AutoMapper;
using Florage.Orders.Contracts;
using Florage.Orders.Dtos;
using Florage.Orders.Models;
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
            _repository.SetCollectionName("Products");
            _mapper = mapper;
        } 

        public async Task<GetProductDto> CreateAsync(CreateProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
             
            Product insertedProduct = await _repository.CreateAsync(product);
            GetProductDto getProductDto = _mapper.Map<GetProductDto>(insertedProduct);
            return getProductDto;
        }

        public async Task<IReadOnlyCollection<GetProductDto>> GetAllAsync()
        {
            IReadOnlyCollection<Product> products = await _repository.GetAllAsync();
            IReadOnlyCollection<GetProductDto> getProducts = _mapper.Map<IReadOnlyCollection<GetProductDto>>(products);
            return getProducts;
        }
    }
}
