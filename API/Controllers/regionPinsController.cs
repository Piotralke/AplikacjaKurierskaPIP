using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class regionPinsController : ControllerBase
	{
		private readonly CourierDbContext _context;
		public regionPinsController(CourierDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<RegionPins>>> GetRegions()
		{
			return await _context.RegionPins.ToListAsync();
		}
		[HttpGet("GetRegionPinByID/{id}")]
		public async Task<ActionResult<RegionPins>> GetRegionPin(int id)
		{
			var region = await _context.RegionPins.FindAsync(id);

			if (region == null)
			{
				return NotFound();
			}

			return region;
		}
		[HttpPost]
		public async Task<ActionResult<RegionPins>> PostRegion(RegionPins region)
		{
			_context.RegionPins.Add(region);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetRegionPins", new { id = region.id }, region);
		}
	}
}
