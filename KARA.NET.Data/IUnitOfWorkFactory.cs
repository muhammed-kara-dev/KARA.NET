namespace KARA.NET.Data;
public interface IUnitOfWorkFactory
    : IService
{
    public IUnitOfWork Create(string connectionName = null);
}