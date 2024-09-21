using System;
using System.Threading.Tasks;

namespace KARA.NET.Business;
public interface IUnitOfWork
    : IDisposable
{
    public void SaveChanges();
    public Task SaveChangesAsync();
}