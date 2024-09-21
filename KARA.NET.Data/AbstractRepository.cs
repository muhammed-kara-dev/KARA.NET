using KARA.NET.Entities;

namespace KARA.NET.Data;
public abstract class AbstractRepository<Entity, Key>
    : IRepository<Entity, Key>
    where Entity : AbstractEntity<Key>
{
}