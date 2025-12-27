using Microsoft.AspNetCore.Mvc;
using PaymentGatewaySystem.Models;

namespace PaymentGatewaySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private static readonly List<Payment> _payments = new();

        public PaymentsController()
        {
            // Constructor is for dependency injection, NOT for HTTP methods!
        }
        [HttpPost]
            public IActionResult CreatePayment([FromBody] Payment payment)
            {
                if (payment == null)
                    return BadRequest("Payment data is required.");

                if (payment.Amount <= 0)
                    return BadRequest("Payment amount must be greater than zero.");

                payment.Id = Guid.NewGuid();
                payment.CreatedAt = DateTime.UtcNow;

                _payments.Add(payment);

                return CreatedAtAction(
                 nameof(GetPayment),
                 new { id = payment.Id },
                 payment);

            }

            [HttpGet("{id}")]
            public IActionResult GetPayment(Guid id)
            {
                var payment = _payments.FirstOrDefault(p => p.Id == id);
                if (payment == null)
                    return NotFound($"Payment with ID {id} not found");
                return Ok(payment);
            }

            [HttpGet]
            public IActionResult GetAllPayments()
            {
                return Ok(_payments);

            }
        
    }
}