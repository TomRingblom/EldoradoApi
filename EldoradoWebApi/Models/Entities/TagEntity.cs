using System.ComponentModel.DataAnnotations;

namespace EldoradoWebApi.Models.Entities
{
    public class TagEntity
    {
        public TagEntity()
        {
                
        }

        public TagEntity(string name)
        {
            Name = name;
        }

        public TagEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<ProductEntity> Products { get; set; } = null!;
    }
}
