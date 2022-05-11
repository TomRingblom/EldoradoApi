namespace EldoradoWebApi.Models.Tags;

public class TagCreate
{
    public TagCreate(string name)
    {
        Name = name;
    }

    public string Name { get; set; } = null!;
}