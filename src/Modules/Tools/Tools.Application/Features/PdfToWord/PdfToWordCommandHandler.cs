using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.PdfToWord;

internal sealed class PdfToWordCommandHandler
    : IRequestHandler<PdfToWordCommand, Result<byte[]>>
{
    public Task<Result<byte[]>> Handle(
        PdfToWordCommand request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}