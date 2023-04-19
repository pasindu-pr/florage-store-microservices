using Florage.Payments.Models;

namespace Florage.Payments.Dtos
{
    public class GetOrderDto
    {
        public string Id { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public float TotalPrice { get; set; }
        public string Status { get; set; } = OrderStatus.Pending.ToString();
    }
}
