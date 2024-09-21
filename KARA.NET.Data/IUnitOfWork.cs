namespace KARA.NET.Data;
public interface IUnitOfWork
    : IDisposable
{
    public bool IsComplete { get; }
    public void Complete();
    public void Flush();
    public Task FlushAsync();
}