using Microsoft.EntityFrameworkCore;

namespace KARA.NET.Data.EntityFramework;
public abstract class BaseUnitOfWorkFactory
    : IUnitOfWorkFactory
{
    protected abstract DbContext CreateDbContext(string connectionName);

    public IUnitOfWork Create(string connectionName = null)
    {
        var dbContext = this.CreateDbContext(connectionName);
        return new BaseUnitOfWork(dbContext);
    }
}