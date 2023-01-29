using API.Data;
using API.Migrations;
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

        [HttpGet("GetAllOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            var users = await _context.AppUsers.ToListAsync();
            var packages = await _context.Packages.ToListAsync();   
            var loginCredentials = await _context.LoginCredentials.ToListAsync();
        
        var result = orders.Select(o =>
        {
            var user = users.FirstOrDefault(u => u.id == o.courierId);
            var package = packages.FirstOrDefault(p => p.id == o.packageId);
            var loginCredentials = user?.loginCredentialsId != null ? _context.LoginCredentials.FirstOrDefault(l => l.id == user.loginCredentialsId) : null;

            return new Order
            {
                id = o.id,
                packageId = o.packageId,
                package = package == null ? null : new Package
                {
                    id = package.id,
                    number = package.number,
                    receiverId = package.receiverId,
                    receiver = package.receiver,
                    receiverAddressId = package.receiverAddressId,
                    receiverAddress = package.receiverAddress,
                    senderId = package.senderId,
                    sender = package.sender,
                    senderAddressId = package.senderAddressId,
                    senderAddress = package.senderAddress,
                    weight = package.weight,
                    width = package.width,
                    depth = package.depth,
                    heigth = package.heigth,
                    description = package.description,
                    isStandardShape = package.isStandardShape,
                    cODcost = package.cODcost,
                    order = package.order,
                    statuses = package.statuses
                },
                price = o.price,
                courierId = o.courierId,
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
        [HttpPost]
		public async Task<ActionResult<Order>> PostOrder(object orderJson)
		{
			string json = JsonSerializer.Serialize(orderJson);
			Order order = JsonSerializer.Deserialize<Order>(json);
			_context.Orders.Add(order);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetOrders", new { id = order.id }, order);
		}

        [HttpPut("UpdateOrderByCourier/{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, [FromBody] Order order)
        {
            try
            {
                var orderDB = await _context.Orders.FindAsync(id);

                if (orderDB == null)
                {
                    return NotFound();
                }

                orderDB.courierId = order.courierId;
                _context.Orders.Update(orderDB);
                await _context.SaveChangesAsync();

                return Ok(orderDB);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
