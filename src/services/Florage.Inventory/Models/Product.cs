using Florage.Shared.Models;

namespace Florage.Inventory.Models
{
    public class Product: BaseEntity
    { 
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double Price { get; set; }
        public double BuyPrice { get; set; }
        public long SellPrice { get; set; }
        public string Category { get; set; } = string.Empty;
        public int StockCount { get; set; }
    }
}
