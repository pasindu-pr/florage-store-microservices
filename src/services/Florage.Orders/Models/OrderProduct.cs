using MongoDB.Driver;

namespace Florage.Orders.Models
{
    public class OrderProduct
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }           
    }
}
