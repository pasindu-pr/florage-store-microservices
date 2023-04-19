namespace Florage.Payments.Dtos
{
    public class CreateOrderDto
    {
        public string Id { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public float TotalPrice { get; set; } 
    }
}
