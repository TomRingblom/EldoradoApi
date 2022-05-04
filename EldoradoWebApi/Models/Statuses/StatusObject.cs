namespace EldoradoWebApi.Models.Statuses;

public class StatusObject
{
    public StatusObject()
    {
        
    }

    public StatusObject(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
}