using KARA.NET.Business;
using KARA.NET.Data;
using Microsoft.Extensions.Logging;

namespace Authorization.Business;
public class AuthorizationService
    : BaseService
{
    public AuthorizationService(ILoggerFactory loggerFactory, IRepositoryFactory repositoryFactory)
        : base(loggerFactory, repositoryFactory)
    {
    }
}