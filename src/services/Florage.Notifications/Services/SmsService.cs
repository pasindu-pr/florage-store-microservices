using Florage.Notifications.Contracts;
using Vonage;
using Vonage.Request;

namespace Florage.Notifications.Services
{
    public class SmsService : ISmsService
    {
        private readonly VonageClient _client;
        private readonly IConfiguration _configuration;
        private Credentials credentials = Credentials.FromApiKeyAndSecret(
                    "53af4316",
                    "vjwfaOxBfg1xMoqG"
                    );

        public SmsService(IConfiguration configuration)
        {
            _client = new VonageClient(credentials);
            _configuration = configuration;
        }
        
        public void SendOrderNotification(string userName, string orderId, float price, string phoneNumber)
        { 

            var response = _client.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
            {
                To = $"94{phoneNumber}",
                From = "Florage Store",
                Text = $"Your order id {orderId} has been received."
            });
        }
    }
}
