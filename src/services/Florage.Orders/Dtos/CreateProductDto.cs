namespace Florage.Orders.Dtos
{
    public class CreateProductDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public float Price { get; set; }
        public double BuyPrice { get; set; }
    }
}
