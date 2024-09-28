using Authorization.Models;
using AutoMapper;
using KARA.NET.Business;
using KARA.NET.Data;
using KARA.NET.Storage;
using Microsoft.Extensions.Logging;

namespace Authorization.Business;
public class UserFacade
    : BaseFacade
{
    private const string STORAGE_USER_ID = nameof(UserFacade.STORAGE_USER_ID);

    private IStorage Storage { get; }
    private UserService UserService { get; }

    public UserFacade(ILoggerFactory loggerFactory, IMapper mapper, IStorage storage, IUnitOfWorkFactory unitOfWorkFactory, UserService userService)
        : base(loggerFactory, mapper, unitOfWorkFactory)
    {
        this.Storage = storage;
        this.UserService = userService;
    }

    public async Task<Guid> GetCurrentUserIDAsync()
    {
        return await this.Storage.ReadAsync(UserFacade.STORAGE_USER_ID, Guid.Empty);
    }

    public async Task SetCurrentUserIDAsync(Guid id)
    {
        await this.Storage.WriteAsync(UserFacade.STORAGE_USER_ID, id);
    }

    public UserModel Get(Guid id)
    {
        using var uow = this.UnitOfWorkFactory.Create(nameof(Authorization));
        var entity = this.UserService.Get(uow, id);
        var model = this.Mapper.Map<UserModel>(entity);
        return model;
    }

    public UserModel Get(string name, string password)
    {
        using var uow = this.UnitOfWorkFactory.Create(nameof(Authorization));
        var entity = this.UserService.Get(uow, name, password);
        var model = this.Mapper.Map<UserModel>(entity);
        return model;
    }

    public bool TryGet(Guid id, out UserModel user)
    {
        using var uow = this.UnitOfWorkFactory.Create(nameof(Authorization));
        if (this.UserService.TryGet(uow, id, out var entity))
        {
            user = this.Mapper.Map<UserModel>(entity);
            return true;
        }
        else
        {
            user = new();
            return false;
        }
    }

    public List<UserModel> GetAll()
    {
        using var uow = this.UnitOfWorkFactory.Create(nameof(Authorization));
        var entities = this.UserService.GetAll(uow);
        var models = entities.Select(this.Mapper.Map<UserModel>).ToList();
        return models;
    }
}