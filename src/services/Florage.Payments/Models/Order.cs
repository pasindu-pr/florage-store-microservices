using Florage.Shared.Models;

namespace Florage.Payments.Models
{
    public class Order: BaseEntity
    {
        public string? UserId { get; set; }
        public float TotalPrice { get; set; }
        public string Status { get; set; } = OrderStatus.Pending.ToString();
    }
}
