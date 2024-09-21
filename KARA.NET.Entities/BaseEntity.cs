namespace KARA.NET.Entities;
public abstract class BaseEntity<TKey>
{
    public TKey ID { get; set; }
}