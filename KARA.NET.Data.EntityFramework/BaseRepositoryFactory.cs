namespace KARA.NET.Data.EntityFramework;
public abstract class BaseRepositoryFactory
    : IRepositoryFactory
{
    public abstract TRepository Create<TRepository>(IUnitOfWork unitOfWork);
}