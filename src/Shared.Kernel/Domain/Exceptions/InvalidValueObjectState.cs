using src.SharedKernel.Domain.Common;

namespace src.SharedKernel.Domain.Exceptions;

public sealed class InvalidValueObjectState : DomainException
{
    public InvalidValueObjectState(string message) : base(message)
    {
    }
}