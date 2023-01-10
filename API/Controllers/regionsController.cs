using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

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
			return await _context.regions.ToListAsync();
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
		[HttpPost]
		public async Task<ActionResult<Region>> PostRegion(Region region)
		{
			_context.regions.Add(region);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetRegion", new { id = region.Id }, region);
		}
	}
}
