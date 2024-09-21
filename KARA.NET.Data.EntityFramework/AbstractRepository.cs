using KARA.NET.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace KARA.NET.Data.EntityFramework;
public abstract class AbstractRepository<Entity, Key>
    : IRepository<Entity, Key>
    where Entity : AbstractEntity<Key>
{
    protected UnitOfWork UnitOfWork { get; }

    private DbContext DbContext
    {
        get => this.UnitOfWork.DbContext;
    }

    protected DbSet<Entity> DbSet
    {
        get => this.DbContext.Set<Entity>();
    }

    protected IQueryable<Entity> Query
    {
        get => this.DbSet.AsQueryable();
    }

    protected AbstractRepository(IUnitOfWork unitOfWork)
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