namespace Florage.Products.Dtos
{
    public class PublishProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double Price { get; set; }
        public int StockCount { get; set; }
        public string Event { get; set; } = string.Empty;
    }
}
