namespace EldoradoWebApi.Models.Categories
{
    public class CategoryUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public CategoryUpdate()
        {

        }

        public CategoryUpdate(string name)
        {
            Name = name;
        }

        public CategoryUpdate(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
