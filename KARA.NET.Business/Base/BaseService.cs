using KARA.NET.Data;
using Microsoft.Extensions.Logging;

namespace KARA.NET.Business;
public abstract class BaseService
{
    protected ILogger Logger { get; }
    protected IRepositoryFactory RepositoryFactory { get; }

    public BaseService(ILoggerFactory loggerFactory, IRepositoryFactory repositoryFactory)
    {
        this.Logger = loggerFactory.CreateLogger(this.GetType());
        this.RepositoryFactory = repositoryFactory;
    }
}