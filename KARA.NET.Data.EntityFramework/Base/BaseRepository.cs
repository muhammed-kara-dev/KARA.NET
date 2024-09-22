using KARA.NET.Entities;
using Microsoft.EntityFrameworkCore;

namespace KARA.NET.Data.EntityFramework;
public abstract class BaseRepository<TEntity>
    : IRepository
    where TEntity : class, IEntity, new()
{
    protected UnitOfWork UnitOfWork { get; }

    private DbContext DbContext
    {
        get => this.UnitOfWork.DbContext;
    }

    protected DbSet<TEntity> DbSet
    {
        get => this.DbContext.Set<TEntity>();
    }

    protected IQueryable<TEntity> Query
    {
        get => this.DbSet.AsQueryable();
    }

    protected BaseRepository(IUnitOfWork unitOfWork)
    {
        if (unitOfWork is UnitOfWork unitOfWorkEF)
        {
            this.UnitOfWork = unitOfWorkEF;
        }
        else
        {
            throw new Exception("unit of work has wrong type");
        }
    }
}