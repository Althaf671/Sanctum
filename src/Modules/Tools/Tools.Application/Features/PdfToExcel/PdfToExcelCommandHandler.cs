using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.PdfToExcel;

internal sealed class PdfToExcelCommandHandler
    : IRequestHandler<PdfToExcelCommand, Result<byte[]>>
{
    public Task<Result<byte[]>> Handle(
        PdfToExcelCommand request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}