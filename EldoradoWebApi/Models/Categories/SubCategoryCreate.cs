namespace EldoradoWebApi.Models.Categories
{
    public class SubCategoryCreate
    {
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }

        public SubCategoryCreate()
        {

        }

        public SubCategoryCreate(string name)
        {
            Name = name;
        }
    }
}
