using KARA.NET.Data;
using KARA.NET.Data.EntityFramework;

namespace KPM.Data.EntityFramework;
public class RepositoryFactory
    : BaseRepositoryFactory
{
    public override TRepository Create<TRepository>(IUnitOfWork unitOfWork)
    {
        return (TRepository)Activator.CreateInstance(typeof(TRepository), unitOfWork);
    }
}