using Florage.Payments.Contracts;
using Florage.Payments.Models;
using Florage.Payments.Utils;
using Florage.Shared.Contracts;
using Florage.Shared.Dtos.Payment;
using Stripe;

namespace Florage.Payments.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IPaymentPublishingService _paymentPublishingService;

        public PaymentService(IRepository<Order> repository, IRepository<Payment> paymentRepository, IPaymentPublishingService paymentPublishingService)
        {
            _orderRepository = repository;
            _orderRepository.SetCollectionName(Constants.OrdersCollectionName);

            _paymentRepository = paymentRepository;
            _paymentRepository.SetCollectionName(Constants.PaymentsCollectionName);

            _paymentPublishingService = paymentPublishingService;
        }

        public async Task CreatePaymentAsync(Event @event)
        {
            var paymentInfomation = @event.Data.Object as Stripe.Checkout.Session;
           
            string orderId = paymentInfomation.Metadata["orderId"];

            Order order = await _orderRepository.GetByIdAsync(orderId);

            if (order != null)
            {
                order.Status = nameof(PaymentStatus.Paid);
                await _orderRepository.UpdateAsync(orderId, order);
            }

            Payment payment = new Payment
            {
                OrderId = orderId,
                Amount = (long)paymentInfomation.AmountTotal,
                Status = nameof(PaymentStatus.Paid),
                PaymentMethod = paymentInfomation.PaymentMethodTypes.FirstOrDefault(),
                PaymentReferenceId = paymentInfomation.Id
            };

            await _paymentRepository.CreateAsync(payment);

            PublishPaymentCreatedDto paymentCreatedDto = new PublishPaymentCreatedDto
            {
                OrderId = orderId,
                UserName = order.User.UserName,
                Email = order.User.Email, 
            };

            await _paymentPublishingService.PublishPaymentCreatedEvent(paymentCreatedDto);
        }
    }
}
