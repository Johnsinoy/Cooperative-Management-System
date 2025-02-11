using Cooperative_Financing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cooperative_Financing.Controllers
{
    [Route("api/Member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly CooperativeContext _context;

        public MemberController(CooperativeContext context)
        {
            _context = context;
        }
        // ✅ GET ALL Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Members>>> GetMembers()
        {
            var members = await _context.Members.ToListAsync();
            return members.Any() ? Ok(members) : NotFound(new { message = "No members found." });
        }

        // ✅ GET Member by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Members>> GetMemberById(int id)
        {
            var member = await _context.Members.FindAsync(id);
            return member != null ? Ok(member) : NotFound(new { message = "Member not found." });
        }

        // ✅ CREATE a New Member
        [HttpPost]
        public async Task<ActionResult<Members>> CreateMember([FromBody] Members member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMemberById), new { id = member.Member_Id }, member);
        }

        // ✅ UPDATE an Existing Member
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] Members member)
        {
            if (id != member.Member_Id)
                return BadRequest(new { message = "ID mismatch." });

            _context.Entry(member).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // ✅ DELETE a Member
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
                return NotFound(new { message = "Member not found." });

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
