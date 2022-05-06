namespace EldoradoWebApi.Models.Categories
{
    public class CategoryUpdate
    {
       
        public string Name { get; set; } = null!;

        public CategoryUpdate()
        {

        }

        public CategoryUpdate(string name)
        {
            Name = name;
        }


    }
}
