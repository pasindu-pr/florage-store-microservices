using Florage.Notifications.Contracts;
using Florage.Shared.Dtos.Payment;
using MassTransit;

namespace Florage.Notifications.AsyncMessaging.Consumers
{
    public class PaymentConfirmedConsumer : IConsumer<PublishPaymentCreatedDto>
    {
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;

        public PaymentConfirmedConsumer(IEmailService emailService, ISmsService smsService)
        {
            _emailService = emailService;
            _smsService = smsService;
        }
        
        public Task Consume(ConsumeContext<PublishPaymentCreatedDto> context)
        {
            var message = context.Message;
            _emailService.SendOrderNotification(message.UserName, message.OrderId, message.Amount, message.Email);
            //_smsService.SendOrderNotification(message.UserName, message.OrderId, message.Amount, message.PhoneNumber);
            return Task.CompletedTask;
        }
    }
}
