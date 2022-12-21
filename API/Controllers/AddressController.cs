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
	public class AddressController : ControllerBase
	{
		private readonly CourierDbContext _context;

		public AddressController(CourierDbContext context)
		{
			_context = context;
		}

		
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
		{
			return await _context.Addresses.ToListAsync();
		}

	}
}
