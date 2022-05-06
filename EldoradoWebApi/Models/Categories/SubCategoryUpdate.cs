namespace EldoradoWebApi.Models.Categories
{
    public class SubCategoryUpdate
    {
     
        public string Name { get; set; } = null!;

        public SubCategoryUpdate()
        {

        }

        public SubCategoryUpdate(string name)
        {
            Name = name;
        }


    }
}
