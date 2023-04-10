using Florage.Shared.Models;

namespace Florage.Payments.Models
{
    public class Payment: BaseEntity
    {
        public string OrderId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public long Amount { get; set; }
        public string Status { get; set; } = nameof(PaymentStatus.Pending);
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentReferenceId { get; set; } = string.Empty;
    }
}
