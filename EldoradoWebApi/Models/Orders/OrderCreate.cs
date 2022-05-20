using EldoradoWebApi.Models.OrderDetails;

namespace EldoradoWebApi.Models.Orders;

public class OrderCreate
{
    public string CustomerId { get; set; } = null!;
    public int AddressId { get; set; }

    public List<OrderDetailsCreate> Details { get; set; }
}

