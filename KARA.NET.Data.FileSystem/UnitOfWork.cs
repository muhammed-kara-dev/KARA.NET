using KARA.NET.Entities;

namespace KARA.NET.Data.FileSystem;
public class UnitOfWork
    : IUnitOfWork
{
    private string FilePath { get; }
    private Dictionary<Type, List<object>> Data { get; }
    public bool IsComplete { get; private set; }

    public UnitOfWork(string connection)
    {
        this.FilePath = StorageUtils.GetFile(connection, "data.json");
        if (File.Exists(this.FilePath))
        {
            var json = File.ReadAllText(this.FilePath);
            this.Data = JsonUtils.Deserialize<Dictionary<Type, List<object>>>(json);
        }
        else
        {
            this.Data = new();
        }
    }

    public void Dispose()
    {
        if (this.IsComplete)
        {
            this.Flush();
        }
        this.Data.Clear();
    }

    public IQueryable<TEntity> GetQuery<TEntity>()
        where TEntity : class, IEntity, new()
    {
        var list = this.Data[typeof(TEntity)];
        return list.Cast<TEntity>().AsQueryable();
    }

    public void Complete()
    {
        this.IsComplete = true;
    }

    public void Flush()
    {
        var json = JsonUtils.Serialize(this.Data);
        File.WriteAllText(this.FilePath, json);
    }
}