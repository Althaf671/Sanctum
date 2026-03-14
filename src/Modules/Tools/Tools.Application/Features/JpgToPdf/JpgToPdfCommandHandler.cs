using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.JpgToPdf;

internal sealed class JpgToPdfCommandHandler
    : IRequestHandler<JpgToPdfCommand, Result<byte[]>>
{
    public Task<Result<byte[]>> Handle(
        JpgToPdfCommand request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}