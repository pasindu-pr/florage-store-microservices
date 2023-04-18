using Florage.Inventory.Models;

namespace Florage.Inventory.Contracts
{
    public interface IProductsMessagingService
    {
        void PublishCreatedProduct(Product product);
        void PublishUpdateProduct(Product product);
        void PublishDeleteProduct(string productId);
    }
}