using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Data;
using PaymentGateway.Models;
using PaymentGateway.Service;

namespace PaymentGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly StripePaymentService _paymentService;
        private readonly ApplicationDbContext _context;

        public PaymentsController(StripePaymentService paymentService, ApplicationDbContext context)
        {
            _paymentService = paymentService;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(decimal amount)
        {
            var paymentIntent = await _paymentService.CreatePayment(amount);

            var transaction = new PaymentTransaction
            {
                Amount = amount,
                PaymentMethod = "Stripe",
                Status = "Processing",
                CreatedAt = DateTime.UtcNow
            };

            _context.PaymentTransactions.Add(transaction);
            await _context.SaveChangesAsync();

            return Ok(paymentIntent);
        }
    }

}
