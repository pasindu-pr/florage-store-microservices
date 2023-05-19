using Florage.Notifications.Contracts;
using Florage.Shared.Dtos.Users;
using MassTransit;

namespace Florage.Notifications.AsyncMessaging.Consumers
{
    public class UserCreatedConsumer : IConsumer<PublishUserCreateDto>
    {
        private readonly IEmailService _emailService;

        public UserCreatedConsumer(IEmailService emailService)
        {
            _emailService = emailService;
        }
        
        public Task Consume(ConsumeContext<PublishUserCreateDto> context)
        {
            _emailService.SendUserRegisterNotification(context.Message.UserName, context.Message.Email);
            return Task.CompletedTask;
        }
    }
}
