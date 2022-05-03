namespace EldoradoWebApi.Models.OrderDetails
{
    public class OrderDetailsObject
    {
        public OrderDetailsObject()
        {

        }
        public OrderDetailsObject(int orderId, double price, int quantity)
        {
            OrderId = orderId;
            Price = price;
            Quantity = quantity;
        }

        public OrderDetailsObject(int orderId, string productName, double price, int quantity)
        {
            OrderId = orderId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }

        public int OrderId { get; set; }
        public string ProductName { get; set; } = null!;
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
