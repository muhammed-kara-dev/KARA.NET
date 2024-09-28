namespace KARA.NET.Entities;
public class EntityMaxLengthAttribute
    : Attribute
{
    public int MaxLength { get; private set; }

    public EntityMaxLengthAttribute(int maxLength)
    {
        this.MaxLength = maxLength;
    }
}