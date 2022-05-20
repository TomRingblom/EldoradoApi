using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EldoradoWebApi.Models.Entities
{
    public class OrderEntity
    {
        public OrderEntity()
        {
        }

        public OrderEntity(string customerId, DateTime orderDate, DateTime orderChangeDate, int adressId)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            OrderChangeDate = orderChangeDate;
            AdressId = adressId;
        }

        public OrderEntity(int id, string customerId, DateTime orderDate, DateTime orderChangeDate)
        {
            Id = id;
            CustomerId = customerId;
            OrderDate = orderDate;
            OrderChangeDate = orderChangeDate;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string CustomerId { get; set; } = null!;
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime OrderChangeDate { get; set; }

        public int AdressId { get; set; }
        public AdressEntity Adress { get; set; }
    }
}
