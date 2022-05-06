using System.ComponentModel.DataAnnotations;

namespace EldoradoWebApi.Models.Entities
{
    public class AdressEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Street { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        [Required]
        public string PostalCode { get; set; } = null!;

        public ICollection<OrderEntity> Order { get; set; } = null!;

    }

}
