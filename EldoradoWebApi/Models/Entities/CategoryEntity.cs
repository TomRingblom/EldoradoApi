using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EldoradoWebApi.Models.Entities
{
    public class CategoryEntity
    {
        public CategoryEntity()
        {

        }

        public CategoryEntity( string name)
        {

            Name = name;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = null!;
    }
}