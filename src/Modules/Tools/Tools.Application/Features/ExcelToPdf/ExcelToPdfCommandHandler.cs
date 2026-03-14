using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.ExcelToPdf;

internal sealed class ExcelToPdfCommandHandler
    : IRequestHandler<ExcelToPdfCommand, Result<byte[]>>
{
    public Task<Result<byte[]>> Handle(
        ExcelToPdfCommand request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}