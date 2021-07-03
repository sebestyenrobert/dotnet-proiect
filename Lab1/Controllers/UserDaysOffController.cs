using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab1.Data;
using Lab1.Models;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDaysOffController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserDaysOffController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserDaysOff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDaysOff>>> GetUsersDaysOffs()
        {
            return await _context.UsersDaysOffs.ToListAsync();
        }

        // GET: api/UserDaysOff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDaysOff>> GetUserDaysOff(int id)
        {
            var userDaysOff = await _context.UsersDaysOffs.FindAsync(id);

            if (userDaysOff == null)
            {
                return NotFound();
            }

            return userDaysOff;
        }

        // PUT: api/UserDaysOff/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDaysOff(int id, UserDaysOff userDaysOff)
        {
            if (id != userDaysOff.Id)
            {
                return BadRequest();
            }

            _context.Entry(userDaysOff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDaysOffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserDaysOff
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDaysOff>> PostUserDaysOff(UserDaysOff userDaysOff)
        {
            _context.UsersDaysOffs.Add(userDaysOff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDaysOff", new { id = userDaysOff.Id }, userDaysOff);
        }

        // DELETE: api/UserDaysOff/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDaysOff(int id)
        {
            var userDaysOff = await _context.UsersDaysOffs.FindAsync(id);
            if (userDaysOff == null)
            {
                return NotFound();
            }

            _context.UsersDaysOffs.Remove(userDaysOff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDaysOffExists(int id)
        {
            return _context.UsersDaysOffs.Any(e => e.Id == id);
        }
    }
}
