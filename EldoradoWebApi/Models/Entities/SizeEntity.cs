using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EldoradoApi.Models.Entities
{
    public class SizeEntity
    {
        public SizeEntity()
        {
        }

        public SizeEntity(string name)
        {
            Name = name;
        }

        public SizeEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductEntity> Products { get; set; } = null!;
    }
}