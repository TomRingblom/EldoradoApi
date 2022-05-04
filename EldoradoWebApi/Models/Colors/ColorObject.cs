namespace EldoradoWebApi.Models.Colors
{
    public class ColorObject
    {
        public ColorObject()
        {

        }
        public ColorObject(string name)
        {
            Name = name;
        }

        public ColorObject(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; }
        public string Name { get; set; }
        
    }
}
