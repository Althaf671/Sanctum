using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace src.App.Common.Behavior;

public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
{
    private readonly ILogger _logger;

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Sanctum Request: ");
    }
}