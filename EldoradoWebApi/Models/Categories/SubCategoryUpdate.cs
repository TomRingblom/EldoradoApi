namespace EldoradoWebApi.Models.Categories
{
    public class SubCategoryUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public SubCategoryUpdate()
        {

        }

        public SubCategoryUpdate(string name)
        {
            Name = name;
        }

        public SubCategoryUpdate(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
