using src.Modules.Tools.ToolsApplication.Common.Enums;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Common.Interfaces;

public interface IPdfConverter
{
    Task<Result<Memory<byte>>> DocumentToPdf(
        Memory<byte> file, 
        DocumentExtensions inputExt, 
        string outputExt, 
        CancellationToken cancellationToken);
}