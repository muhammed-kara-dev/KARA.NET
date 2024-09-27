using KARA.NET.Data;
using PasswordManager.Entities;

namespace PasswordManager.Data;
public class PasswordRepository
    : BaseRepository<Password>
{
    public PasswordRepository(IUnitOfWork uow)
        : base(uow)
    {
    }

    public Password GetByID(Guid id)
    {
        return this.Query.First(x => x.ID == id);
    }

    public List<Password> GetAll()
    {
        return this.Query.ToList();
    }
}