namespace KARA.NET.Data;
public interface IUnitOfWorkFactory
{
    public IUnitOfWork Create(string connection = null);
}