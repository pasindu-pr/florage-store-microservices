using Florage.Notifications.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Florage.Notifications.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;

        public EmailController(IEmailService emailService, ISmsService smsService)
        {
            _emailService = emailService;
            _smsService = smsService;
        }

        [HttpGet("mail")]
        public IActionResult SendEmail()
        {
            _emailService.SendOrderNotification("Pasindu", "123", 1000.00f);
            return Ok();
        }


        [HttpGet("sms")]
        public IActionResult SendSms()
        {
            _smsService.SendOrderNotification("Pasindu", "123", 1000.00f);
            return Ok();
        }
    }
}
