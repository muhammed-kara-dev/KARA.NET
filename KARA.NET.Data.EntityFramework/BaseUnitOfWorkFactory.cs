using Microsoft.EntityFrameworkCore;

namespace KARA.NET.Data.EntityFramework;
public abstract class BaseUnitOfWorkFactory
    : IUnitOfWorkFactory
{
    protected abstract DbContext CreateDbContext(string database);

    public IUnitOfWork Create(string database = null)
    {
        var dbContext = this.CreateDbContext(database);
        return new BaseUnitOfWork(dbContext);
    }
}