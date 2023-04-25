namespace Florage.Notifications.Contracts
{
    public interface IEmailService
    {
        void SendOrderNotification(string userName, string orderId, float price);
    }
}
