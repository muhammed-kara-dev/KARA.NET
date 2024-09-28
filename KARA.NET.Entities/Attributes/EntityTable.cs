namespace KARA.NET.Entities;
public class EntityTable
    : Attribute
{
    public string Name { get; }

    public EntityTable(string name)
    {
        this.Name = name;
    }
}