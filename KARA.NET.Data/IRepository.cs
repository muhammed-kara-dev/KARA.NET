using KARA.NET.Entities;

namespace KARA.NET.Data;
public interface IRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
{
}