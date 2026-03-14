using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.WordToPdf;

internal sealed class WordToPdfCommandHandler
    : IRequestHandler<WordToPdfCommand, Result<byte[]>>
{
    public Task<Result<byte[]>> Handle(
        WordToPdfCommand request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}