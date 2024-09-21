using Microsoft.EntityFrameworkCore;

namespace KARA.NET.Data.EntityFramework;
public abstract class UnitOfWorkFactory
    : IUnitOfWorkFactory
{
    protected abstract DbContext CreateDbContext(string connectionName);

    public IUnitOfWork Create(string connectionName = null)
    {
        var dbContext = this.CreateDbContext(connectionName);
        return new UnitOfWork(dbContext);
    }
}