using Authorization.Models;
using AutoMapper;
using KARA.NET;
using KARA.NET.Business;
using KARA.NET.Data;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Security.Principal;

namespace Authorization.Business;
public class AuthorizationService
    : BaseService, IAuthorizationService
{
    public IIdentity Identity { get; }

    public AuthorizationService(ILoggerFactory loggerFactory, IMapper mapper, IRepositoryFactory repositoryFactory, IUnitOfWorkFactory unitOfWorkFactory, UserService userService)
        : base(loggerFactory, repositoryFactory)
    {
        using var uow = unitOfWorkFactory.Create(nameof(Authorization));
        if (userService.TryGet(uow, Guid.Parse("5bd5bda4-3a99-4145-884c-377dacf5f48f"), out var entity)) // TODO storage
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