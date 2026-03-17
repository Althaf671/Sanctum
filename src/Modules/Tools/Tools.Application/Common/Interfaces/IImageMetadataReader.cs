using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Common.Interfaces;

public interface IImageMetadataReader
{
    Task<Result<ImageMasterMetadataDetail>> ReadImageMetadata(
        Memory<byte> file, CancellationToken cancellationToken);
}