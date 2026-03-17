using MediatR;
using src.Modules.Tools.ToolsApplication.Common.Enums;
using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.OfficeMetadataReader;

public record OfficeMetadataReaderCommand(Memory<byte> File, OfficeDocumentType Type)
    : IRequest<Result<OfficeMetadataDetail>>;