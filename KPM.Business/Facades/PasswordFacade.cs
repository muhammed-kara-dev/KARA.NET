using AutoMapper;
using KARA.NET.Business;
using KARA.NET.Data;
using KPM.Models;

namespace KPM.Business;
public class PasswordFacade
    : BaseFacade
{
    private PasswordService PasswordService { get; }

    public PasswordFacade(IMapper mapper, IUnitOfWorkFactory unitOfWorkFactory, PasswordService passwordService)
        : base(mapper, unitOfWorkFactory)
    {
        this.PasswordService = passwordService;
    }

    public PasswordModel GetByID(Guid id)
    {
        using var uow = this.UnitOfWorkFactory.Create();
        var entity = this.PasswordService.GetByID(uow, id);
        var model = this.Mapper.Map<PasswordModel>(entity);
        return model;
    }

    public List<PasswordModel> GetAll()
    {
        using var uow = this.UnitOfWorkFactory.Create();
        var entities = this.PasswordService.GetAll(uow);
        var models = entities.Select(this.Mapper.Map<PasswordModel>).ToList();
        return models;
    }
}