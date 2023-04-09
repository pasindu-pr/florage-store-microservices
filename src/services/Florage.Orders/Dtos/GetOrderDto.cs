using Florage.Orders.Models;

namespace Florage.Orders.Dtos
{
    public class GetOrderDto
    {
        public string Id { get; set; } = string.Empty;
        public List<OrderProduct>  Products { get; set; } = new List<OrderProduct>();
        public string? UserId { get; set; }
        public float TotalPrice { get; set; }
        public string Status { get; set; } = OrderStatus.Pending.ToString();
    }
}
