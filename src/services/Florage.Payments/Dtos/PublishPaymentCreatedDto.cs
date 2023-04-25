namespace Florage.Payments.Dtos
{
    public class PublishPaymentCreatedDto
    {
        public string OrderId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
