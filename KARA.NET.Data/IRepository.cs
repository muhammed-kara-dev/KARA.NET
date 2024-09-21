using KARA.NET.Entities;

namespace KARA.NET.Data;
public interface IRepository<Entity, Key>
    where Entity : AbstractEntity<Key>
{
}