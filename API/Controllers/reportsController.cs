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
	public class reportsController : ControllerBase
	{
		private readonly CourierDbContext _context;

		public reportsController(CourierDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Report>>> GetReports()
		{
			return await _context.Reports.ToListAsync();
		}



		[HttpPost]
		public async Task<ActionResult<Report>> PostReport(object statusJson)
		{
			string json = JsonSerializer.Serialize(statusJson);
			Report report = JsonSerializer.Deserialize<Report>(json);

			object[] paramItems = new object[]
{
				new SqlParameter("@paramNumPackage", report.numPackage),
				new SqlParameter("@paramDate", report.date),
				new SqlParameter("@paramDesc", report.desc),
};
			int items = _context.Database.ExecuteSqlRaw("INSERT INTO Reports([numPackage],[date], [desc]) " +
				"VALUES(@paramNumPackage, @paramDate," +
				" @paramDesc)", paramItems);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetStatuses", new { id = report.id }, report);
		}

	}
}
