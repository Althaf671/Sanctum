// using MediatR;
// using Microsoft.Extensions.Logging;
// using src.App.GetAggregateMetricQuery;

// namespace src.App.Features.Module.Overview.Queries.GetAggregateMetricQueryHandler;

// internal sealed class GetAggregateMetricQueryHandler
//     : IRequestHandler<GetAggregateMetricQueryDto, object>
// {
//     private readonly ILogger<GetAggregateMetricQueryHandler> _logger;

//     public GetAggregateMetricQueryHandler(
//         ILogger<GetAggregateMetricQueryHandler> logger)
//     {
//         _logger = logger;
//     }

//     public Task<object> Handle(
//         GetAggregateMetricQueryDto request, 
//         CancellationToken cancellationToken)
//     {
//         _logger.LogInformation("");

//         _logger.LogInformation("");
//     }
// }