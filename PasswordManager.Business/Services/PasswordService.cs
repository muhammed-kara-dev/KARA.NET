using KARA.NET.Business;
using KARA.NET.Data;
using Microsoft.Extensions.Logging;
using PasswordManager.Data.EntityFramework;
using PasswordManager.Entities;

namespace PasswordManager.Business;
public class PasswordService
    : BaseService
{
    public PasswordService(ILoggerFactory loggerFactory, IRepositoryFactory repositoryFactory)
        : base(loggerFactory, repositoryFactory)
    {
    }

    public Password GetByID(IUnitOfWork uow, Guid id)
    {
        var repo = this.RepositoryFactory.Create<PasswordRepository>(uow);
        return repo.GetByID(id);
    }

    public List<Password> GetAll(IUnitOfWork uow)
    {
        var repo = this.RepositoryFactory.Create<PasswordRepository>(uow);
        return repo.GetAll();
    }
}