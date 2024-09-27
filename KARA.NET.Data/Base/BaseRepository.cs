using KARA.NET.Entities;

namespace KARA.NET.Data;
public abstract class BaseRepository<TEntity>
    : IRepository
    where TEntity : class, IEntity, new()
{
    protected IUnitOfWork UnitOfWork { get; }

    protected IQueryable<TEntity> Query
    {
        get => this.UnitOfWork.GetQuery<TEntity>();
    }

    protected BaseRepository(IUnitOfWork unitOfWork)
    {
        this.UnitOfWork = unitOfWork;
    }
}