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
    public class UserDaysOffOfficialController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserDaysOffOfficialController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserDaysOffOfficial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDaysOffOfficial>>> GetUsersDaysOffOfficials()
        {
            return await _context.UsersDaysOffOfficials.ToListAsync();
        }

        // GET: api/UserDaysOffOfficial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDaysOffOfficial>> GetUserDaysOffOfficial(int id)
        {
            var userDaysOffOfficial = await _context.UsersDaysOffOfficials.FindAsync(id);

            if (userDaysOffOfficial == null)
            {
                return NotFound();
            }

            return userDaysOffOfficial;
        }

        // PUT: api/UserDaysOffOfficial/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDaysOffOfficial(int id, UserDaysOffOfficial userDaysOffOfficial)
        {
            if (id != userDaysOffOfficial.Id)
            {
                return BadRequest();
            }

            _context.Entry(userDaysOffOfficial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDaysOffOfficialExists(id))
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

        // POST: api/UserDaysOffOfficial
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDaysOffOfficial>> PostUserDaysOffOfficial(UserDaysOffOfficial userDaysOffOfficial)
        {
            _context.UsersDaysOffOfficials.Add(userDaysOffOfficial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDaysOffOfficial", new { id = userDaysOffOfficial.Id }, userDaysOffOfficial);
        }

        // DELETE: api/UserDaysOffOfficial/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDaysOffOfficial(int id)
        {
            var userDaysOffOfficial = await _context.UsersDaysOffOfficials.FindAsync(id);
            if (userDaysOffOfficial == null)
            {
                return NotFound();
            }

            _context.UsersDaysOffOfficials.Remove(userDaysOffOfficial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDaysOffOfficialExists(int id)
        {
            return _context.UsersDaysOffOfficials.Any(e => e.Id == id);
        }
    }
}
