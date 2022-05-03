namespace EldoradoApi.Models.Sizes;

public class SizeObject
{
    public SizeObject()
    {
        
    }

    public SizeObject(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
}