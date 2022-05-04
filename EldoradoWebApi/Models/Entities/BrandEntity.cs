using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EldoradoWebApi.Models.Entities
{
    public class BrandEntity
    {
        public BrandEntity()
        {
        }

        public BrandEntity(string name)
        {
            Name = name;
        }

        public BrandEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductEntity> Products { get; set; } = null!;
    }
}