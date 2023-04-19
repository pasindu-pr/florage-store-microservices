namespace Florage.Shared.Dtos.Orders
{
    public class PublishCreateOrderDto
    {
        public string Id { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public float TotalPrice { get; set; }
    }
}
