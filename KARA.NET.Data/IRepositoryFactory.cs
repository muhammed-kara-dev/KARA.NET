namespace KARA.NET.Data;
public interface IRepositoryFactory
    : IService
{
    public TRepository Create<TRepository>(IUnitOfWork unitOfWork);
}