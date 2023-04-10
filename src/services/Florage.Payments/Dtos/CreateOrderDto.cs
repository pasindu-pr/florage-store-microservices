using Florage.Payments.Models;

namespace Florage.Payments.Dtos
{
    public class CreateOrderDto
    {
        public string? UserId { get; set; }
        public float TotalPrice { get; set; } 
    }
}
