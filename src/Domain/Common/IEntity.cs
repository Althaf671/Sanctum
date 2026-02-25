namespace src.Domain.Common;
public interface IEntity
{
    Guid Id { get; }

    DateTime CreatedAt { get; }
}