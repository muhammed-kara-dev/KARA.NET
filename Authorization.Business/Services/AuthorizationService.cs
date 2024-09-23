using Authorization.Entities;
using KARA.NET;
using KARA.NET.Business;
using KARA.NET.Data;
using Microsoft.Extensions.Logging;

namespace Authorization.Business;
public class AuthorizationService
    : BaseService, IAuthorizationService
{
    private User User { get; }

    public bool IsAuthorized
    {
        get => this.User != null;
    }

    public AuthorizationService(ILoggerFactory loggerFactory, IRepositoryFactory repositoryFactory, IUnitOfWorkFactory unitOfWorkFactory, UserService userService)
        : base(loggerFactory, repositoryFactory)
    {
        using var uow = unitOfWorkFactory.Create(nameof(Authorization));
        if (userService.TryGet(uow, Guid.Parse("5bd5bda4-3a99-4145-884c-377dacf5f48f"), out var user)) // TODO storage
        {
            this.User = user;
        }
    }
}