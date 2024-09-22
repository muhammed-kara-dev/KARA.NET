namespace KARA.NET.Data;
public class RepositoryFactory
    : IRepositoryFactory
{
    public TRepository Create<TRepository>(IUnitOfWork unitOfWork)
        where TRepository : class, IRepository
    {
        return (TRepository)Activator.CreateInstance(typeof(TRepository), unitOfWork);
    }
}