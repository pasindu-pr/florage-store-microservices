using Florage.Shared.Models;

namespace Florage.Orders.Models
{
    public class Order: BaseEntity
    {
        public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();
        public User? UserId { get; set; }
        public float TotalPrice { get; set; }
        public string Status { get; set; } = OrderStatus.Pending.ToString();
    }
}
