using Cooperative_Financing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cooperative_Financing.Controllers
{
    [Route("api/datauser")]
    [ApiController]
    public class DatauserController : ControllerBase
    {
        private readonly CooperativeContext _context;

        public DatauserController(CooperativeContext context)
        {
            _context = context;
        }

        // ✅ GET ALL Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataUsers>>> GetDataUsers()
        {
            return await _context.DataUsers.ToListAsync();
        }

        // ✅ GET a Single User by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<DataUsers>> GetDataUserById(int id)
        {
            var user = await _context.DataUsers.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found." });

            return user;
        }

        // ✅ CREATE a New User
        [HttpPost]
        public async Task<ActionResult<DataUsers>> CreateDataUser([FromBody] DataUsers user)
        {
            if (user == null)
                return BadRequest(new { message = "Invalid data." });

            _context.DataUsers.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDataUserById), new { id = user.User_Id }, user);
        }

        // ✅ UPDATE an Existing User
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDataUser(int id, [FromBody] DataUsers user)
        {
            if (id != user.User_Id)
                return BadRequest(new { message = "User ID mismatch." });

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataUserExists(id))
                    return NotFound(new { message = "User not found." });

                throw;
            }

            return NoContent();
        }

        // ✅ DELETE a User
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataUser(int id)
        {
            var user = await _context.DataUsers.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found." });

            _context.DataUsers.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ Helper Method to Check if User Exists
        private bool DataUserExists(int id)
        {
            return _context.DataUsers.Any(e => e.User_Id == id);
        }
    }
}
