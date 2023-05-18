using Florage.Shared.Models;

namespace Florage.Orders.Models
{
    public class Product: BaseEntity
    { 
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public float Price { get; set; }
        public double BuyPrice { get; set; }
    }
}
