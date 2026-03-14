using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.JpgToWebp;

internal sealed class JpgToWebpCommandHandler
    : IRequestHandler<JpgToWebpCommand, Result<byte[]>>
{
    public Task<Result<byte[]>> Handle(
        JpgToWebpCommand request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}