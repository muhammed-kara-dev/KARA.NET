using AutoMapper;
using KARA.NET.Data;

namespace KARA.NET.Business;
public abstract class BaseFacade
    : IService
{
    protected IMapper Mapper { get; }
    protected IUnitOfWorkFactory UnitOfWorkFactory { get; }

    public BaseFacade(IMapper mapper, IUnitOfWorkFactory unitOfWorkFactory)
    {
        this.Mapper = mapper;
        this.UnitOfWorkFactory = unitOfWorkFactory;
    }
}