namespace EldoradoWebApi.Models.OrderDetails
{
    public class OrderDetailsCreate
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; } 
        public int Quantity { get; set; }   


    }
}
