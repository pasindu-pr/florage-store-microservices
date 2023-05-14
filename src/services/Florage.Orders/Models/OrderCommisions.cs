using Florage.Shared.Models;

namespace Florage.Orders.Models
{
    public class OrderCommisions: BaseEntity
    { 
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public double Commision { get; set; }
    }
}
