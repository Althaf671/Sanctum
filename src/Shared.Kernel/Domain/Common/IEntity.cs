namespace src.SharedKernel.Domain.Common;
public interface IEntity
{
    Guid Id { get; }

    bool IsDeleted { get; } 

    DateTime? UpdatedAt { get; }

    DateTime CreatedAt { get; }

    public Result Delete();
}