using KARA.NET.Data;

namespace KARA.NET.Business;
public abstract class BaseService
    : IService
{
    protected IRepositoryFactory RepositoryFactory { get; }

    public BaseService(IRepositoryFactory repositoryFactory)
    {
        this.RepositoryFactory = repositoryFactory;
    }
}