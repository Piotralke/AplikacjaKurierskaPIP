using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class packagesController : ControllerBase
	{
		private readonly CourierDbContext _context;

		public packagesController(CourierDbContext context)
		{
			_context = context;
		}

		[HttpGet("GetAllPackages")]
		public async Task<ActionResult<IEnumerable<Package>>> GetAllPackages()
		{
			var package = await _context.Packages.
				Select(u => new Package
				{
					id = u.id,
					number = u.number,
					ReceiverId = u.ReceiverId,
					Receiver = u.Receiver,
					receiverAddressId = u.receiverAddressId,
					receiverAddress = u.receiverAddress,
					SenderId = u.SenderId,
					Sender = u.Sender,
					senderAddressId = u.senderAddressId,
					senderAddress = u.senderAddress,
					weight = u.weight,
					width = u.width,
					depth = u.depth,
					heigth = u.heigth,
					description = u.description,
					isStandardShape = u.isStandardShape,
					CODcost = u.CODcost,
					order = u.order,
					statuses = u.statuses
				}).ToListAsync();
			if (package == null)
			{
				return NotFound();
			}

			return package;
		}

		[HttpGet("GetYoursPackages/{id}")]
		public async Task<ActionResult<IEnumerable<Package>>> GetYoursPackages(int id)
		{
			var package = await _context.Packages.Where(u=>u.ReceiverId==id || u.SenderId == id).
				Select(u => new Package
				{
					id = u.id,
					number = u.number,
					ReceiverId = u.ReceiverId,
					Receiver = u.Receiver,
					receiverAddressId = u.receiverAddressId,
					receiverAddress = u.receiverAddress,
					SenderId = u.SenderId,
					Sender = u.Sender,
					senderAddressId = u.senderAddressId,
					senderAddress = u.senderAddress,
					weight = u.weight,
					width = u.width,
					depth = u.depth,
					heigth = u.heigth,
					description = u.description,
					isStandardShape = u.isStandardShape,
					CODcost = u.CODcost,
					order = u.order,
					statuses = u.statuses
				}).ToListAsync();
			if (package == null)
			{
				return NotFound();
			}

			return package;
		}

		[HttpGet("GetPackageByID/{id}")]
		public async Task<ActionResult<Package>> GetUser(int id)
		{
			var package = await _context.Packages.FindAsync(id);

			if (package == null)
			{
				return NotFound();
			}

			return package;
		}
		[HttpGet("GetPackageByNumber/{number}")]
		public async Task<ActionResult<Package>> GetPackageByNumber(string number)
		{
			var package = await _context.Packages.Where(u => u.number == number).
				Select(u => new Package
				{
					id = u.id,
					number=u.number,
					ReceiverId=u.ReceiverId,
					Receiver=u.Receiver,
					receiverAddressId= u.receiverAddressId,
					receiverAddress=u.receiverAddress,
					SenderId=u.SenderId,
					Sender=u.Sender,
					senderAddressId=u.senderAddressId,
					senderAddress=u.senderAddress,
					weight=u.weight,
					width=u.width,
					depth=u.depth,
					heigth=u.heigth,
					description=u.description,
					isStandardShape=u.isStandardShape,
					CODcost=u.CODcost,
					order=u.order,
					statuses=u.statuses
				}).FirstOrDefaultAsync();
			if (package == null)
			{
				return NotFound();
			}

			return package;
		}

		[HttpPut("PutPackage/{id}")]
		public async Task<IActionResult> PutPackage(int id, Package package)
		{
			if (id != package.id)
			{
				return BadRequest();
			}

			_context.Entry(package).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PackageExists(id))
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

		[HttpPost]
		public async Task<ActionResult<Package>> PostPackage(object packageJson)
		{
			string json = JsonSerializer.Serialize(packageJson);
			Package package = JsonSerializer.Deserialize<Package>(json);
			_context.Packages.Add(package);
			await _context.SaveChangesAsync();
		

            return CreatedAtAction("GetUser", new { id = package.id }, package);
		}

		[HttpDelete("DeletePackageById/{id}")]
		public async Task<IActionResult> DeletePackage(int id)
		{
			var package = await _context.Packages.FindAsync(id);
			if (package == null)
			{
				return NotFound();
			}

			_context.Packages.Remove(package);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool PackageExists(int id)
		{
			return _context.Packages.Any(e => e.id == id);
		}

		private void SaveChangesWithIdentityInsert()
		{
			using var transaction = _context.Database.BeginTransaction();
			_context.Database.ExecuteSqlRawAsync($"SET INDENTITY_INSERT Addresses ON");
			_context.SaveChanges();
            _context.Database.ExecuteSqlRawAsync($"SET INDENTITY_INSERT Addresses OFF");
			transaction.Commit();
        }
    }
}
