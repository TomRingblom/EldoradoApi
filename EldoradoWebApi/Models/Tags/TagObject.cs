namespace EldoradoWebApi.Models.Tags;

public class TagObject
{
    public TagObject()
    {
        
    }

    public TagObject(string name)
    {
        Name = name;
    }

    public TagObject(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
}