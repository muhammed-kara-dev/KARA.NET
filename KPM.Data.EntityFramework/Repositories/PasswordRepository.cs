using KARA.NET.Data;
using KARA.NET.Data.EntityFramework;
using KPM.Entities;

namespace KPM.Data.EntityFramework;
public class PasswordRepository
    : BaseRepository<Password, Guid>
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