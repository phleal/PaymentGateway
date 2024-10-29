using Stripe;

namespace PaymentGateway.Service
{
    public class StripePaymentService
    {
        public async Task<PaymentIntent> CreatePayment(decimal amount, string currency = "usd")
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100), // valor em centavos
                Currency = currency,
                PaymentMethodTypes = new List<string> { "card" }
            };
            var service = new PaymentIntentService();
            return await service.CreateAsync(options);
        }
    }

}
