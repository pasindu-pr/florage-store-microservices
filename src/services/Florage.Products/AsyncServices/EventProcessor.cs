using AutoMapper;
using Florage.Products.Contracts;
using Florage.Products.Dtos;
using System.Text.Json;

namespace Florage.Products.AsyncServices
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        {
            _scopeFactory = serviceScopeFactory;
            _mapper = mapper;
        }
        
        public void ProcessEvent(string message)
        {
            var eventType = GetEventType(message);

            switch (eventType)
            {
                case EventType.ProductCreated:
                    createProduct(message);
                    break;
            }
        }

        private async void createProduct(string createdProductNotification)
        {
            // Get a scoped service inside singleton instance
            using (var scope = _scopeFactory.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IProductsService>();

                PublishProductDto createdProduct = JsonSerializer.Deserialize<PublishProductDto>(createdProductNotification);
                await service.CreateAsync(_mapper.Map<CreateProductDto>(createdProduct));                
            }
        }

        private EventType GetEventType(string notificationMessage)
        {
            Console.WriteLine("Detemining event type");
            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch (eventType.Event)
            {
                case nameof(EventType.ProductCreated):
                    Console.WriteLine("Product created");
                    return EventType.ProductCreated;
                default:
                    Console.WriteLine("Cannot determine event");
                    return EventType.Undertermined;
            }
        }
        
        private enum EventType
        {
            ProductCreated,
            ProductUpdated,
            ProductDeleted,
            Undertermined
        }
    }


}
