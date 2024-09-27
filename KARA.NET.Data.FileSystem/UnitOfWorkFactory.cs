namespace KARA.NET.Data.FileSystem;
public class UnitOfWorkFactory
    : IUnitOfWorkFactory
{
    public IUnitOfWork Create(string connection = null)
    {
        return new UnitOfWork(connection);
    }
}