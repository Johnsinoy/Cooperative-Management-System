using Cooperative_Financing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/Loan")]
[ApiController]
public class LoanController : ControllerBase
{
    private readonly CooperativeContext _context;

    public LoanController(CooperativeContext context)
    {
        _context = context;
    }

    // ✅ GET ALL Loans
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Loans>>> GetLoans()
    {
        return await _context.Loans.ToListAsync();
    }

    // ✅ GET a Single Loan by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Loans>> GetLoanById(int id)
    {
        var loan = await _context.Loans.FindAsync(id);
        if (loan == null)
            return NotFound(new { message = "Loan not found." });

        return loan;
    }

    // ✅ CREATE a New Loan
    [HttpPost]
    public async Task<ActionResult<Loans>> CreateLoan([FromBody] Loans loan)
    {
        if (loan == null || loan.Member_Id == 0)
        {
            return BadRequest(new { message = "Member_Id is required." });
        }

        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLoanById), new { id = loan.Loan_Id }, loan);
    }

    // ✅ UPDATE an Existing Loan
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLoan(int id, [FromBody] Loans loan)
    {
        if (id != loan.Loan_Id)
            return BadRequest(new { message = "Loan ID mismatch." });

        _context.Entry(loan).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LoanExists(id))
                return NotFound(new { message = "Loan not found." });

            throw;
        }

        return NoContent();
    }

    // ✅ DELETE a Loan
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLoan(int id)
    {
        var loan = await _context.Loans.FindAsync(id);
        if (loan == null)
            return NotFound(new { message = "Loan not found." });

        _context.Loans.Remove(loan);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // ✅ Helper Method to Check if Loan Exists
    private bool LoanExists(int id)
    {
        return _context.Loans.Any(e => e.Loan_Id == id);
    }
}
