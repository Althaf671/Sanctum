using MediatR;
using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.ImageMetadataReader;

public record ImageMetadataReaderCommand(Memory<byte> File, CancellationToken CancellationToken) 
    : IRequest<Result<ImageMasterMetadataDetail>>;