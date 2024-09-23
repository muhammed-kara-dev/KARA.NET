using Authorization.Models;
using AutoMapper;
using KARA.NET;
using KARA.NET.Business;
using KARA.NET.Data;
using KARA.NET.Storage;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Security.Principal;

namespace Authorization.Business;
public class AuthorizationService
    : BaseService, IAuthorizationService
{
    private const string SESSION_ID = $"{nameof(AuthorizationService)}.{nameof(SESSION_ID)}";

    public IIdentity Identity { get; }

    public AuthorizationService(ILoggerFactory loggerFactory, IMapper mapper, IRepositoryFactory repositoryFactory, IStorage storage, IUnitOfWorkFactory unitOfWorkFactory, UserService userService)
        : base(loggerFactory, repositoryFactory)
    {
        var id = storage.ReadAsync(AuthorizationService.SESSION_ID, Guid.Empty).Result;
        using var uow = unitOfWorkFactory.Create(nameof(Authorization));
        if (userService.TryGet(uow, id, out var entity))
        {
            var model = mapper.Map<UserModel>(entity);
            this.Identity = model;
        }
        else
        {
            this.Identity = new ClaimsIdentity();
        }
    }
}