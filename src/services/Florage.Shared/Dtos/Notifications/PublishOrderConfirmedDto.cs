namespace Florage.Shared.Dtos.Notifications
{
    public class PublishOrderConfirmedDto
    {
        public string OrderId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserPhoneNumber { get; set; } = string.Empty;
        public float Price { get; set; }
    }
}
