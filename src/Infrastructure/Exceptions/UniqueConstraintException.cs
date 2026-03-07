namespace src.Infrastructure.Exceptions;

public class UniqueConstraintException : InfrastructureException
{
    public UniqueConstraintException(string message) : base(message)
    {
    }
}