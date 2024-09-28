namespace KARA.NET.Entities;
public class EntityMaxLength
    : Attribute
{
    public int MaxLength { get; }

    public EntityMaxLength(int maxLength)
    {
        this.MaxLength = maxLength;
    }
}