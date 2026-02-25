namespace src.Domain.Common;

public sealed class InvalidValueObjectState : DomainException
{
    public InvalidValueObjectState(string message) : base(message)
    {
    }
}