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
    private const string SESSION_ID = $"{nameof(AuthorizationService)}.{nameof(AuthorizationService.SESSION_ID)}";

    private IStorage Storage { get; }
    private Guid UserID { get; }
    public IIdentity Identity { get; }

    public AuthorizationService(ILoggerFactory loggerFactory, IMapper mapper, IRepositoryFactory repositoryFactory, IStorage storage, IUnitOfWorkFactory unitOfWorkFactory, UserService userService)
        : base(loggerFactory, repositoryFactory)
    {
        this.Storage = storage;
        var id = storage.ReadAsync(AuthorizationService.SESSION_ID, Guid.Empty).Result;
        using var uow = unitOfWorkFactory.Create(nameof(Authorization));
        if (userService.TryGet(uow, id, out var entity))
        {
            var model = mapper.Map<UserModel>(entity);
            this.UserID = model.ID;
            this.Identity = model;
        }
        else
        {
            this.UserID = Guid.Empty;
            this.Identity = new ClaimsIdentity();
        }
    }

    public async Task LoginAsync(string name, string password)
    {
        await this.Storage.WriteAsync(AuthorizationService.SESSION_ID, this.UserID);
    }

    public async Task LogoutAsync()
    {
        await this.Storage.WriteAsync(AuthorizationService.SESSION_ID, Guid.Empty);
    }
}