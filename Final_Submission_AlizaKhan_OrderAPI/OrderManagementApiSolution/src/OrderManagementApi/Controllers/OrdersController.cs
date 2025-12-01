using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementApi.Data;
using OrderManagementApi.DTOs;
using OrderManagementApi.Models;
using System.Security.Claims;

namespace OrderManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OrdersController(ApplicationDbContext context)
    {
        _context = context;
    }

    private string GetUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        var userId = GetUserId();
        var orders = await _context.Orders
            .Where(o => o.UserId == userId)
            .ToListAsync();

        return Ok(orders);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var userId = GetUserId();
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);

        if (order is null) return NotFound();
        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(OrderDto dto)
    {
        var userId = GetUserId();
        var order = new Order
        {
            ProductName = dto.ProductName,
            Quantity = dto.Quantity,
            UnitPrice = dto.UnitPrice,
            TotalAmount = dto.Quantity * dto.UnitPrice,
            UserId = userId
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateOrder(int id, OrderDto dto)
    {
        var userId = GetUserId();
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);

        if (order is null) return NotFound();

        order.ProductName = dto.ProductName;
        order.Quantity = dto.Quantity;
        order.UnitPrice = dto.UnitPrice;
        order.TotalAmount = dto.Quantity * dto.UnitPrice;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var userId = GetUserId();
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);

        if (order is null) return NotFound();

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
