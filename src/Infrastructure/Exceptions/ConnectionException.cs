namespace src.Infrastructure.Exceptions;

public class ConnectionException : InfrastructureException
{
    public ConnectionException(string message) : base(message)
    {
    }
}