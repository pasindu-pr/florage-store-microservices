namespace Florage.Shared.Dtos.Payment
{
    public class PublishPaymentCreatedDto
    {
        public string OrderId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public float Amount { get; set; }
    }
}
