using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.SharedKernel.Domain.Common;

namespace src.Infrastructure.Services.Converters;

public class DocumentConverter : IDocumentConverter
{
    public Task<Result<byte[]>> ExcelToPdf(byte[] file, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<byte[]>> PdfToExcel(byte[] file, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<byte[]>> PdfToWord(byte[] file, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<byte[]>> WordToPdf(byte[] file, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}