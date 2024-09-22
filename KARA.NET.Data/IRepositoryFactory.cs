namespace KARA.NET.Data;
public interface IRepositoryFactory
{
    public TRepository Create<TRepository>(IUnitOfWork unitOfWork)
        where TRepository : class;
}