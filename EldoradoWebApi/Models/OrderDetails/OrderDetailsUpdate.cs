namespace EldoradoWebApi.Models.OrderDetails
{
    public class OrderDetailsUpdate
    {
        public OrderDetailsUpdate()
        {

        }
        public OrderDetailsUpdate(int orderId, int quantity, double price)
        {
            OrderId = orderId;
            Quantity = quantity;
            Price = price;
        }

        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
