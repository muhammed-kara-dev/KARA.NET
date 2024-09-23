namespace KARA.NET;
public interface IUser
{
    public Guid ID { get; }
    public string Name { get; }
    public string Email { get; }
}