using EldoradoApi.Models.Entities;
using EldoradoApi.Models.Orders;

namespace EldoradoApi.Services;

public interface IOrderService
{
    Task CreateOrder(OrderCreate model);
    Task<IEnumerable<OrderObject>> GetOrders();
    Task<OrderObject> GetOrderById(int id);
    Task<OrderObject> UpdateOrder(int id, OrderUpdate model);
    Task<OrderObject> DeleteOrder(int id);
}