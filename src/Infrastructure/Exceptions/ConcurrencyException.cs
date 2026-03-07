namespace src.Infrastructure.Exceptions;

public class ConcurrencyException : InfrastructureException
{
    public ConcurrencyException(string message) : base(message)
    {
    }
}