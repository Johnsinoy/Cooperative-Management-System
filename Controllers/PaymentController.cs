using Cooperative_Financing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cooperative_Financing.Controllers
{
    [Route("api/Payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly CooperativeContext _context;

        public PaymentController(CooperativeContext context)
        {
            _context = context;
        }

        // ✅ GET ALL Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payments>>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }

        // ✅ GET a Single Payment by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Payments>> GetPaymentById(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
                return NotFound(new { message = "Payment not found." });

            return payment;
        }

        // ✅ CREATE a New Payment
        [HttpPost]
        public async Task<ActionResult<Payments>> CreatePayment([FromBody] Payments payment)
        {
            if (payment == null)
                return BadRequest(new { message = "Invalid data." });

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Payment_Id }, payment);
        }

        // ✅ UPDATE an Existing Payment
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] Payments payment)
        {
            if (id != payment.Payment_Id)
                return BadRequest(new { message = "Payment ID mismatch." });

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
                    return NotFound(new { message = "Payment not found." });

                throw;
            }

            return NoContent();
        }

        // ✅ DELETE a Payment
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
                return NotFound(new { message = "Payment not found." });

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ Helper Method to Check if Payment Exists
        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.Payment_Id == id);
        }
    }
}