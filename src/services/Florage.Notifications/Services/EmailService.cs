using Azure;
using Azure.Communication.Email;
using Florage.Notifications.Contracts;
using Florage.Notifications.Settings;

namespace Florage.Notifications.Services
{
    public class EmailService: IEmailService
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }    

        public void SendOrderNotification(string userName, string orderId, float price)
        {
            EmailSettings mailSettings = _configuration.GetSection("EmailSettings").Get<EmailSettings>(); ;
            var client = new EmailClient(mailSettings.ConnectionString);

            try
            {
                var emailSendOperation = client.Send(
                    wait: WaitUntil.Completed,
                    senderAddress: "billing@f34ddddc-71f2-4111-bac2-ae18bafa8444.azurecomm.net",
                    recipientAddress: "pasinduprabashitha@gmail.com",
                    subject: "This is the subject",
                    htmlContent: "<html><body>This is the html body</body></html>");

                _logger.LogInformation($"Email Sent. Status = {emailSendOperation.Value.Status}");

                /// Get the OperationId so that it can be used for tracking the message for troubleshooting
                string operationId = emailSendOperation.Id;
                _logger.LogInformation($"Email operation id = {operationId}");
            }
            catch (RequestFailedException ex)
            {
                _logger.LogInformation($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
            }
        }
    }
}
