namespace Florage.Inventory.Dtos
{
    public class CreateProductDto
    { 
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double Price { get; set; }
        public int StockCount { get; set; }
        public double BuyPrice { get; set; }
        public long SellPrice { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
