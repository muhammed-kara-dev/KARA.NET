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

    private IMapper Mapper { get; }
    private IStorage Storage { get; }
    private IUnitOfWorkFactory UnitOfWorkFactory { get; }
    private UserService UserService { get; }
    private Guid UserID { get; set; }
    public IIdentity Identity { get; private set; } = new ClaimsIdentity();

    public AuthorizationService(ILoggerFactory loggerFactory, IMapper mapper, IRepositoryFactory repositoryFactory, IStorage storage, IUnitOfWorkFactory unitOfWorkFactory, UserService userService)
        : base(loggerFactory, repositoryFactory)
    {
        this.Mapper = mapper;
        this.Storage = storage;
        this.UnitOfWorkFactory = unitOfWorkFactory;
        this.UserService = userService;
    }

    public async Task InitAsync()
    {
        var id = await this.Storage.ReadAsync(AuthorizationService.SESSION_ID, Guid.Empty);
        using var uow = this.UnitOfWorkFactory.Create(nameof(Authorization));
        if (this.UserService.TryGet(uow, id, out var entity))
        {
            var model = this.Mapper.Map<UserModel>(entity);
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