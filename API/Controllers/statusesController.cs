using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class statusesController : ControllerBase
	{
		private readonly CourierDbContext _context;

		public statusesController(CourierDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
		{
			return await _context.Statuses.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Status>> PostStatus(object statusJson)
		{
			string json = JsonSerializer.Serialize(statusJson);
			Status status = JsonSerializer.Deserialize<Status>(json);

			object[] paramItems = new object[]
{           
				new SqlParameter("@paramIdStatus", status.idStatusName),
				new SqlParameter("@paramIdPackage", status.idPackage),
				new SqlParameter("@paramDate", status.date),
}; 
            int items = _context.Database.ExecuteSqlRaw("INSERT INTO Statuses([idStatusName],[idPackage], [date]) " +
				"VALUES(@paramIdStatus, @paramIdPackage," +
				" @paramDate)", paramItems);
			//_context.Database.ExecuteSqlRaw(ss);
		//	_context.Statuses.Add(newStatus);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetStatuses", new { id = status.Id }, status);
		}

	}
}
