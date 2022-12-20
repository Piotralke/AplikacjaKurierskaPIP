using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class loginCredentialsController : ControllerBase
    {

        private readonly CourierDbContext _context;

        public loginCredentialsController(CourierDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<loginCredentials>>> GetLoginCredentials()
        {
            return await _context.LoginCredentials.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("GetLoginCredentialsByID/{id}")]
        public async Task<ActionResult<loginCredentials>> GetLoginCredentials(int id)
        {
            var credentials = await _context.LoginCredentials.FindAsync(id);

            if (credentials == null)
            {
                return NotFound();
            }

            return credentials;
        }
        [HttpGet("GetLoginCredentialsByLogin/{login}")]
        public async Task<ActionResult<loginCredentials>> GetLoginCredentialsByLogin(string login)
        {
            var credentials = await _context.LoginCredentials.Where(c=>login.Equals(c.login)).FirstOrDefaultAsync();
            if (credentials == null)
            {
                return NotFound();
            }

            return credentials;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutLoginCredentials/{id}")]
        public async Task<IActionResult> PutLoginCredentials(int id, loginCredentials credentials)
        {
            if (id != credentials.id)
            {
                return BadRequest();
            }

            _context.Entry(credentials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginCredentialsExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<loginCredentials>> PostLoginCredentials(loginCredentials credentials)
        {
            _context.LoginCredentials.Add(credentials);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = credentials.id }, credentials);
        }

        // DELETE: api/Users/5
        [HttpDelete("DeleteLoginCredentialsById/{id}")]
        public async Task<IActionResult> DeleteLoginCredentials(int id)
        {
            var credentials = await _context.LoginCredentials.FindAsync(id);
            if (credentials == null)
            {
                return NotFound();
            }

            _context.LoginCredentials.Remove(credentials);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginCredentialsExists(int id)
        {
            return _context.LoginCredentials.Any(e => e.id == id);
        }
    }
}
