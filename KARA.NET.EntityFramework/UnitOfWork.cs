using KARA.NET.Business;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KARA.NET.EntityFramework;
public class UnitOfWork
    : IUnitOfWork
{
    private DbContext DbContext { get; }

    public UnitOfWork()
    {
        this.DbContext = new DbContext();
    }

    public void Dispose()
    {
        this.DbContext.Dispose();
    }

    public void SaveChanges()
    {
        this.DbContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await this.DbContext.SaveChangesAsync();
    }
}