using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace KARA.NET.Data.EntityFramework;
public class UnitOfWork
    : IUnitOfWork
{
    private DbContext DbContext { get; }
    private IDbContextTransaction Transaction { get; }
    public bool IsComplete { get; private set; }

    public UnitOfWork(DbContext dbContext)
    {
        this.DbContext = dbContext;
        this.Transaction = dbContext.Database.BeginTransaction();
    }

    public void Dispose()
    {
        if (this.IsComplete)
        {
            this.Flush();
            this.Transaction.Commit();
        }
        else
        {
            this.Transaction.Rollback();
        }
        this.Transaction.Dispose();
        this.DbContext.Dispose();
    }

    public void Complete()
    {
        this.IsComplete = true;
    }

    public void Flush()
    {
        this.DbContext.SaveChanges();
    }

    public async Task FlushAsync()
    {
        await this.DbContext.SaveChangesAsync();
    }
}