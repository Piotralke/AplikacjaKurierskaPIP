using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using System.Reflection.Metadata;
using System.Text.Json;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CourierDbContext _context;

        public UsersController(CourierDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAppUsers()
        {
            return await _context.AppUsers.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("GetUserByID/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.AppUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("GetUserByLogin/{login}")]
        public async Task<ActionResult<User>> GetUserByLogin(string login)
        {
            var user = await _context.AppUsers.Where(u => u.loginCredentials.login == login).
                Select(u=>new User
                {
                    id=u.id,
                    name=u.name,
                    surname=u.surname,
                    loginCredentialsId=u.loginCredentialsId,
                    loginCredentials=u.loginCredentials,
                    role=u.role,
                    defaultAddressId=u.defaultAddressId,
                    defaultAddress=u.defaultAddress,
                    senderPackages=u.senderPackages,
                    receiverPackages=u.receiverPackages,
                    orders=u.orders,
                    phoneNumber=u.phoneNumber,
                    region=u.region

                }).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("GetAllWorkers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllWorkers()
        {
            return  await _context.AppUsers.Where(u => u.role == 0 || u.role == 1).
                 Select(u => new User
                 {
                     id = u.id,
                     name = u.name,
                     surname = u.surname,
                     loginCredentialsId = u.loginCredentialsId,
                     loginCredentials = u.loginCredentials,
                     role = u.role,
                     defaultAddressId = u.defaultAddressId,
                     defaultAddress = u.defaultAddress,
                     senderPackages = u.senderPackages,
                     receiverPackages = u.receiverPackages,
                     orders = u.orders,
                     phoneNumber = u.phoneNumber,
                     region = u.region

                 }).ToListAsync();

        }
        [HttpGet("GetAllCouriers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllCouriers()
        {
            return await _context.AppUsers.Where(u => u.role == 1).
                Select(u => new User
                {
                    id = u.id,
                    name = u.name,
                    surname = u.surname,
                    loginCredentialsId = u.loginCredentialsId,
                    loginCredentials = u.loginCredentials,
                    role = u.role,
                    defaultAddressId = u.defaultAddressId,
                    defaultAddress = u.defaultAddress,
                    senderPackages = u.senderPackages,
                    receiverPackages = u.receiverPackages,
                    orders = u.orders,
                    phoneNumber = u.phoneNumber,
                    region = u.region

                }).ToListAsync();

        }
        [HttpGet("GetUserByPhoneNumber/{phone}")]
		public async Task<ActionResult<User>> GetUserByPhoneNumber(string phone)
		{
			var user = await _context.AppUsers.Where(u => u.phoneNumber == phone).
				Select(u => new User
				{
					id = u.id,
					name = u.name,
					surname = u.surname,
					loginCredentialsId = u.loginCredentialsId,
					loginCredentials = u.loginCredentials,
					role = u.role,
					defaultAddressId = u.defaultAddressId,
					defaultAddress = u.defaultAddress,
					senderPackages = u.senderPackages,
					receiverPackages = u.receiverPackages,
					orders = u.orders,
                    phoneNumber=u.phoneNumber,
                    region=u.region

				}).FirstOrDefaultAsync();
			if (user == null)
			{
				return NotFound();
			}

			return user;
		}

		// PUT: api/Users/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("PutUser/{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        public async Task<ActionResult<User>> PostUser(object userJson)
        {
            string json = JsonSerializer.Serialize(userJson);
			User user = JsonSerializer.Deserialize<User>(json);
            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("DeleteUserById/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.AppUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.AppUsers.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.AppUsers.Any(e => e.id == id);
        }
    }
}
