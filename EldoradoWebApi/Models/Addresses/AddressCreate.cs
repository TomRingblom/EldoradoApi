using System.ComponentModel.DataAnnotations;

namespace EldoradoWebApi.Models.Addresses
{
    public class AddressCreate
    {

        public AddressCreate()
        {

        }
        public AddressCreate(string street, string city, string postalCode)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        public AddressCreate(string customerId, string street, string city, string postalCode)
        {
            CustomerId = customerId;
            Street = street;
            City = city;
            PostalCode = postalCode;
        }

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
