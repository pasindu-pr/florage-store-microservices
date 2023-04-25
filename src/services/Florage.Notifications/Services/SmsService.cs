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
                    "5330883a",
                    "cteW8eTUQEQrNzb9"
                    );

        public SmsService(IConfiguration configuration)
        {
            _client = new VonageClient(credentials);
            _configuration = configuration;
        }
        
        public void SendOrderNotification(string userName, string orderId, float price)
        { 

            var response = _client.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
            {
                To = "94773279388",
                From = "Florage Store",
                Text = "A text message sent using the Vonage SMS API"
            });
        }
    }
}
