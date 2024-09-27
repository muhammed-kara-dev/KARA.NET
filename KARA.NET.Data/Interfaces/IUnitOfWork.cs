using KARA.NET.Entities;

namespace KARA.NET.Data;
public interface IUnitOfWork
    : IDisposable
{
    public bool IsComplete { get; }
    public IQueryable<TEntity> GetQuery<TEntity>()
        where TEntity : class, IEntity, new();
    public void Complete();
    public void Flush();
}