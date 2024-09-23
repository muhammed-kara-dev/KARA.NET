using Authorization.Models;
using AutoMapper;
using KARA.NET.Business;
using KARA.NET.Data;
using Microsoft.Extensions.Logging;

namespace Authorization.Business;
public class UserFacade
    : BaseFacade
{
    private UserService UserService { get; }

    public UserFacade(ILoggerFactory loggerFactory, IMapper mapper, IUnitOfWorkFactory unitOfWorkFactory, UserService userService)
        : base(loggerFactory, mapper, unitOfWorkFactory)
    {
        this.UserService = userService;
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

    public List<UserModel> GetAll()
    {
        using var uow = this.UnitOfWorkFactory.Create(nameof(Authorization));
        var entities = this.UserService.GetAll(uow);
        var models = entities.Select(this.Mapper.Map<UserModel>).ToList();
        return models;
    }
}