using src.Modules.Tools.ToolsApplication.Common.Enums;
using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Common.Interfaces;

public interface IOfficeMetadataReader
{
    Task<Result<OfficeMetadataDetail>> ReadOfficeMetadata(
        Memory<byte> file, 
        OfficeDocumentType documentType,
        CancellationToken cancellationToken);
}