namespace src.SharedKernel.Domain.Common;
public interface IEntity
{
    Guid Id { get; }

    DateTime CreatedAt { get; }
}