using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Text.Json;

namespace API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class regionsController : ControllerBase
	{
		private readonly CourierDbContext _context;
		public regionsController(CourierDbContext context)
		{
			_context = context;
		}
		[HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            var regions = await _context.regions.ToListAsync();
            var users = await _context.AppUsers.ToListAsync();
            var loginCredentials = await _context.LoginCredentials.ToListAsync();

            var result = regions.Select(r =>
            {
                var user = users.FirstOrDefault(u => u.id == r.courierId);
                var loginCredentials = user?.loginCredentialsId != null ? _context.LoginCredentials.FirstOrDefault(l => l.id == user.loginCredentialsId) : null;

                return new Region
                {
                    id = r.id,
                    code = r.code,
                    courierId = r.courierId,
                    courier = user == null ? null : new User
                    {
                        id = user.id,
                        name = user.name,
                        surname = user.surname,
                        loginCredentialsId = user.loginCredentialsId,
                        role = user.role,
                        defaultAddressId = user.defaultAddressId,
                        defaultAddress = user.defaultAddress,
                        senderPackages = user.senderPackages,
                        receiverPackages = user.receiverPackages,
                        orders = user.orders,
                        phoneNumber = user.phoneNumber,
                        loginCredentials = loginCredentials == null ? null : new loginCredentials
                        {
                            id = loginCredentials.id,
                            email = loginCredentials.email,
                            login = loginCredentials.login,
                            password = loginCredentials.password
                        }
                    }
                };
            }).ToArray();

            return result;
        }

        [HttpGet("GetRegionByID/{id}")]
		public async Task<ActionResult<Region>> GetRegion(int id)
		{
			var region = await _context.regions.FindAsync(id);

			if (region == null)
			{
				return NotFound();
			}

			return region;
		}
        [HttpGet("GetRegionByCode/{code}")]
        public async Task<ActionResult<Region>> GetRegionByCode(string code)
        {
            var region = await _context.regions.Where(x => x.code.Equals(code)).FirstOrDefaultAsync();

            if (region == null)
            {
                return NotFound();
            }

            return region;
        }
        [HttpPost]
		public async Task<ActionResult<Region>> PostRegion(object regionjson)
		{
			string json = JsonSerializer.Serialize(regionjson);
			Region region = JsonSerializer.Deserialize<Region>(json);
			_context.regions.Add(region);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetRegion", new { id = region.id }, region);
		}
        [HttpPut("UpdateRegionByCourier/{courierId}")]
        public async Task<ActionResult<Region>> UpdateRegion(int id,int courierId)
        {
            try
            {
                var region = await _context.regions.FindAsync(id);

                if (region == null)
                {
                    return NotFound();
                }

                region.courierId = courierId;
                _context.regions.Update(region);
                await _context.SaveChangesAsync();

                return Ok(region);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteRegionById/{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            var region = await _context.regions.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionPins = _context.RegionPins.Where(rp => rp.regionId == id);
            _context.RegionPins.RemoveRange(regionPins);


            _context.regions.Remove(region);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
