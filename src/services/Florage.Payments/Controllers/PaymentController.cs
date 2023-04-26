using Florage.Payments.Contracts; 
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Florage.Payments.Controllers
{
    [Route("api/payments")]
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
            try
            {
                var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
                //var enpointSecret = "whsec_7f178c6838b0aac09181e1c02d01e92c785397bd7e50d58841e24a8c073291e5";
                var enpointSecret = "we_1N1AkkHJfferNMkthpCvsZ05"; 
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
