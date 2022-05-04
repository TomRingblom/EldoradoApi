namespace EldoradoWebApi.Models.Brands
{
    public class BrandObject
    {
        public BrandObject()
        {

        }

        public BrandObject(string name)
        {
            Name = name;
        }

        public BrandObject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; set; }

    }
}
