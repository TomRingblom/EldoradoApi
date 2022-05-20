using System.ComponentModel.DataAnnotations;

namespace EldoradoWebApi.Models.Addresses
{
    public class AddressObject
    {

        public AddressObject()
        {

        }
        public AddressObject(string street, string city, string postalCode)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        public AddressObject(string customerId, string street, string city, string postalCode)
        {
            CustomerId = customerId;
            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        public AddressObject(int id, string customerId, string street, string city, string postalCode)
        {
            Id = id;
            CustomerId = customerId;
            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public string Street { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        [Required]
        public string PostalCode { get; set; } = null!;

    }
}
