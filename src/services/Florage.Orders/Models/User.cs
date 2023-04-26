using Florage.Shared.Models;

namespace Florage.Orders.Models
{
    public class User: BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
