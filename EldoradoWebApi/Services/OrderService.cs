using EldoradoWebApi.Data;
using EldoradoWebApi.Models.Entities;
using EldoradoWebApi.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace EldoradoWebApi.Services;

public class OrderService : IOrderService
{
    private readonly SqlContext _context;
    private readonly IOrderDetailsService _orderDetailsService;
    public OrderService(SqlContext context, IOrderDetailsService details)
    {
        _context = context;
        _orderDetailsService = details;
        
    }
    
    public async Task CreateOrder(OrderCreate model)
    {
        var entity = await _context.Orders.AddAsync(new OrderEntity(model.CustomerId, DateTime.Now, DateTime.Now, model.AddressId));
        foreach(var item in model.Details)
        {
            await _orderDetailsService.CreateDetails(item);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrderObject>> GetOrders()
    {
        var orders = new List<OrderObject>();
        foreach (var order in await _context.Orders.ToListAsync())
        {
            orders.Add(new OrderObject(order.Id, order.CustomerId, order.OrderDate, order.OrderChangeDate));
        }
        return orders;
    }

    public async Task<OrderObject> GetOrderById(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        if (order == null)
        {
            return null!;
        }
        else
        {
            return new OrderObject(order.Id, order.CustomerId, order.OrderDate, order.OrderChangeDate);
        }
            
        
    }

    public async Task<OrderObject> UpdateOrder(int id, OrderUpdate model)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
            return null!;

        order.CustomerId = model.CustomerId;
        order.OrderChangeDate = DateTime.Now;

        _context.Entry(order).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return new OrderObject(order.CustomerId, order.OrderDate, order.OrderChangeDate);
    }

    public async Task<OrderObject> DeleteOrder(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        if (order == null)
            return null!;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return new OrderObject(order.CustomerId, order.OrderDate, order.OrderChangeDate);
    }
}