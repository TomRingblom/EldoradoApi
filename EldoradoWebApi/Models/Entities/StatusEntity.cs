using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EldoradoWebApi.Models.Entities
{
    public class StatusEntity
    {
        public StatusEntity()
        {
        }

        public StatusEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductEntity> Products { get; set; } = null!;
    }
}