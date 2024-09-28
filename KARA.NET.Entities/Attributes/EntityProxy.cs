namespace KARA.NET.Entities;
public class EntityProxy
    : Attribute
{
    public string Key { get; }
    public string Collection { get; }

    public EntityProxy(string key, string collection)
    {
        this.Key = key;
        this.Collection = collection;
    }
}