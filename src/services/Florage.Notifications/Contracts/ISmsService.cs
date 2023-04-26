namespace Florage.Notifications.Contracts
{
    public interface ISmsService
    {
        void SendOrderNotification(string userName, string orderId, float price, string phoneNumber);
    }
}
