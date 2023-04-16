using Florage.Inventory.Models;

namespace Florage.Inventory.Contracts
{
    public interface IProductsMessagingService
    {
        void PublishCreatedProduct(Product product);
    }
}