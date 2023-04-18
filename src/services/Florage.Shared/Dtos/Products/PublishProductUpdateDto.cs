namespace Florage.Shared.Dtos.Products
{
    public class PublishProductUpdateDto
    {
        public string Id = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double Price { get; set; }
        public int StockCount { get; set; }
    }
}
