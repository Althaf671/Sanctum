using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Common.Interfaces;

public interface IDocumentConverter
{
    Task<Result<byte[]>> WordToPdf(byte[] file, CancellationToken cancellationToken);

    Task<Result<byte[]>> ExcelToPdf(byte[] file, CancellationToken cancellationToken);

    Task<Result<byte[]>> PdfToWord(byte[] file, CancellationToken cancellationToken);

    Task<Result<byte[]>> PdfToExcel(byte[] file, CancellationToken cancellationToken);
}