namespace EldoradoWebApi.Models.Orders
{
    public class OrderObject
    {
        public OrderObject(string customerId, DateTime orderDate, DateTime orderChangeDate)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            OrderChangeDate = orderChangeDate;
        }

        public OrderObject(int id, string customerId, DateTime orderDate, DateTime orderChangeDate)
        {
            Id = id;
            CustomerId = customerId;
            OrderDate = orderDate;
            OrderChangeDate = orderChangeDate;
        }

        public int Id { get; set; }
        public string CustomerId { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public DateTime OrderChangeDate { get; set; }
    }
}
