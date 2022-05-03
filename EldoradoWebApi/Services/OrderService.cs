﻿using EldoradoApi.Data;
using EldoradoApi.Models.Entities;
using EldoradoApi.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace EldoradoApi.Services;

public class OrderService : IOrderService
{
    private readonly SqlContext _context;

    public OrderService(SqlContext context)
    {
        _context = context;
    }
    
    public async Task CreateOrder(OrderCreate model)
    {
        await _context.Orders.AddAsync(new OrderEntity(model.CustomerId, DateTime.Now, DateTime.Now));
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
        return new OrderObject(order.Id, order.CustomerId, order.OrderDate, order.OrderChangeDate);
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