using System.ComponentModel.DataAnnotations;

namespace EldoradoWebApi.Models.Addresses
{
    public class AddressUpdate
    {
        public AddressUpdate()
        {

        }

        public AddressUpdate(string street, string city, string postalCode)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        public AddressUpdate(string CustomerId, string street, string city, string postalCode)
        {
            this.CustomerId = CustomerId;
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
