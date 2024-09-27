using Authorization.Entities;
using KARA.NET.Data;

namespace Authorization.Data;
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

    public bool TryGet(Guid id, out User user)
    {
        user = this.Query.FirstOrDefault(x => x.ID == id);
        return user != null;
    }

    public List<User> GetAll()
    {
        return this.Query.ToList();
    }
}