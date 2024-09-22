namespace KARA.NET.Entities;
public abstract class BaseEntity<TKey>
    : IEntity
{
    public TKey ID { get; set; }
}