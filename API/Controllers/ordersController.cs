using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ordersController : ControllerBase
	{
		private readonly CourierDbContext _context;

		public ordersController(CourierDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
		{
			return await _context.Orders.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Order>> PostOrder(object orderJson)
		{
			string json = JsonSerializer.Serialize(orderJson);
			Order order = JsonSerializer.Deserialize<Order>(json);
			_context.Orders.Add(order);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetOrder", new { id = order.id }, order);
		}

	}
}
