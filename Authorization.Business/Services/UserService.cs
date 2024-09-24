using Authorization.Data.EntityFramework;
using Authorization.Entities;
using KARA.NET.Business;
using KARA.NET.Data;
using Microsoft.Extensions.Logging;

namespace Authorization.Business;
public class UserService
    : BaseService
{
    public UserService(ILoggerFactory loggerFactory, IRepositoryFactory repositoryFactory)
        : base(loggerFactory, repositoryFactory)
    {
    }

    public User Get(IUnitOfWork uow, Guid id)
    {
        var repo = this.RepositoryFactory.Create<UserRepository>(uow);
        return repo.Get(id);
    }

    public bool TryGet(IUnitOfWork uow, Guid id, out User user)
    {
        var repo = this.RepositoryFactory.Create<UserRepository>(uow);
        return repo.TryGet(id, out user);
    }

    public User Get(IUnitOfWork uow, string name, string password)
    {
        var repo = this.RepositoryFactory.Create<UserRepository>(uow);
        return repo.Get(name, password);
    }

    public List<User> GetAll(IUnitOfWork uow)
    {
        var repo = this.RepositoryFactory.Create<UserRepository>(uow);
        return repo.GetAll();
    }
}