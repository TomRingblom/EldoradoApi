using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EldoradoWebApi.Models.Entities;

public class OrderDetailsEntity
{
    public OrderDetailsEntity()
    {
    }

    public OrderDetailsEntity(int orderId, int productId, string productName, double price, int quantity)
    {
        OrderId = orderId;
        ProductId = productId;
        Product.Name = productName;
        Price = price;
        Quantity = quantity;
    }

    public OrderDetailsEntity(int id, int orderId, OrderEntity order, int productId, ProductEntity product, int quantity, double price)
    {
        Id = id;
        OrderId = orderId;
        Order = order;
        ProductId = productId;
        Product = product;
        Quantity = quantity;
        Price = price;
    }

    [Key]
    public int Id { get; set; }
    
    [Required]
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; } = null!;

    [Required]
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;

    [Required]
    public int Quantity { get; set; }
    [Required]
    [Column(TypeName = "money")]
    public double Price { get; set; }
}