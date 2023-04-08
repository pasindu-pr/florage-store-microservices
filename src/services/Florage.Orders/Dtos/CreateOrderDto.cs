namespace Florage.Orders.Dtos
{
    public class CreateOrderDto
    {
        public List<OrderProductDto> Products { get; set; } = new List<OrderProductDto>(); 
    }
}
