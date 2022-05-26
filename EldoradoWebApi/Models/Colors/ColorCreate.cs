namespace EldoradoWebApi.Models.Colors
{
    public class ColorCreate
    {
        public ColorCreate(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
