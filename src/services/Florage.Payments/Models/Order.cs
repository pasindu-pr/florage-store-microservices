using Florage.Shared.Models;

namespace Florage.Payments.Models
{
    public class Order: BaseEntity
    {
        public User User { get; set; }
        public float TotalPrice { get; set; }
        public string Status { get; set; } = OrderStatus.Pending.ToString();
    }
}
