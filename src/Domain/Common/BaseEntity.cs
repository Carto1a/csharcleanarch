namespace CSharpCleanArch.Domain.Common;
public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; private set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }
}