using Florage.Payments.Contracts; 
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Florage.Payments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IConfiguration _configuration;

        public PaymentController(IPaymentService paymentService, IConfiguration configuration)
        {
            _paymentService = paymentService;
            _configuration = configuration;
        }

        [HttpPost("webhook")]
        public async Task<IActionResult> Webhook()
        {
            Console.WriteLine("Webhook called");
            try
            {
                var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
                var enpointSecret = _configuration.GetValue<string>("Stripe:SigningSecret");
                var signatureHeader = Request.Headers["Stripe-Signature"];
                Event stripeEvent = EventUtility.ConstructEvent(json, signatureHeader, enpointSecret);
                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {

                    await _paymentService.CreatePaymentAsync(stripeEvent);
                    return Ok();
                }

                return BadRequest();

            }
            catch (StripeException e)
            {
                Console.WriteLine(e);
                return BadRequest();
            } 
        }
    }
}
