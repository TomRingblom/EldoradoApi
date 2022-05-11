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

        public AddressObject(int userId, string street, string city, string postalCode)
        {
            UserId = userId;
            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        [Required]
        public int UserId { get; set; }
        [Required]
        public string Street { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        [Required]
        public string PostalCode { get; set; } = null!;

    }
}
