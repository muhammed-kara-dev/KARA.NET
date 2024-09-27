using AutoMapper;
using KARA.NET.Data;
using Microsoft.Extensions.Logging;

namespace KARA.NET.Business;
public abstract class BaseFacade
{
    protected ILogger Logger { get; }
    protected IMapper Mapper { get; }
    protected IUnitOfWorkFactory UnitOfWorkFactory { get; }

    public BaseFacade(ILoggerFactory loggerFactory, IMapper mapper, IUnitOfWorkFactory unitOfWorkFactory)
    {
        this.Logger = loggerFactory.CreateLogger(this.GetType());
        this.Mapper = mapper;
        this.UnitOfWorkFactory = unitOfWorkFactory;
    }
}