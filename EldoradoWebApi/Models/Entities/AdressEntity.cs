using System.ComponentModel.DataAnnotations;

namespace EldoradoWebApi.Models.Entities
{
    public class AdressEntity
    {
        public AdressEntity(string customerId, string street, string city, string postalCode)
        {
            CustomerId =  customerId;
            Street = street;
            City = city;
            PostalCode = postalCode;
        }
        public AdressEntity()
        {

        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public string Street { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        [Required]
        public string PostalCode { get; set; } = null!;

        public ICollection<OrderEntity> Order { get; set; } = null!;

    }

}
