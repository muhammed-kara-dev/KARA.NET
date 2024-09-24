using KARA.NET.Entities;

namespace KARA.NET.Data;
public interface ISeed
{
    public void Build(Action<IEntity> add);
}