using System.ComponentModel.DataAnnotations;

namespace EldoradoWebApi.Models.Entities
{
    public class TagEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<ProductEntity> Products { get; set; } = null!;
    }
}
