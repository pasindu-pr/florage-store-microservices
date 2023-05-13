namespace Florage.Orders.Models
{
    public class OrderCommisions
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public double Commision { get; set; }
    }
}
