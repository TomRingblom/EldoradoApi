namespace EldoradoWebApi.Models.Categories
{
    public class CategoryObject
    {

        public string Name { get; set; } = null!;

        public CategoryObject()
        {

        }

        public CategoryObject(string name)
        {
            Name = name;
        }
    }
}
