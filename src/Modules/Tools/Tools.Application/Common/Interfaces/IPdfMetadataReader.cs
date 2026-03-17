using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Common.Interfaces;

public interface IPdfMetadataReader
{
    Task<Result<PdfMetadataDetail>> ReadPdfMetadata(Memory<byte> file);
}