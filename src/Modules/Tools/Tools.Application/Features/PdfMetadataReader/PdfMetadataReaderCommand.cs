using MediatR;
using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.PdfMetadataReader;

public record PdfMetadataReaderCommand(Memory<byte> File) 
    : IRequest<Result<PdfMetadataDetail>>;