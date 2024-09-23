using Authorization.Entities;
using KARA.NET.Data;
using KARA.NET.Data.EntityFramework;

namespace Authorization.Data.EntityFramework;
public class UserRepository
    : BaseRepository<User>
{
    public UserRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
    }

    public User Get(Guid id)
    {
        return this.Query.First(x => x.ID == id);
    }

    public User Get(string name, string password)
    {
        return this.Query.First(x => x.Name == name && x.Password == password);
    }

    public List<User> GetAll()
    {
        return this.Query.ToList();
    }
}