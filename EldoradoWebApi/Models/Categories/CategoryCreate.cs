namespace EldoradoWebApi.Models.Categories
{
    public class CategoryCreate
    {
        public string Name { get; set; } = null!;

        public CategoryCreate()
        {

        }

        public CategoryCreate(string name)
        {
            Name = name;
        }
    }
}
