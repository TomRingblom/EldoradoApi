namespace EldoradoWebApi.Models.Orders;

public class OrderCreate
{
    public string CustomerId { get; set; } = null!;
    public int AddressId { get; set; }
}

