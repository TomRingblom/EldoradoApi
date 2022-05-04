namespace EldoradoWebApi.Models.Categories
{
    public class SubCategoryObject
    {
        public string Name { get; set; } = null!;

        public SubCategoryObject()
        {

        }

        public SubCategoryObject(string name)
        {
            Name = name;
        }
    }
}
