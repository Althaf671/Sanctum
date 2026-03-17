using MediatR;
using src.Modules.Tools.ToolsApplication.Common.Enums;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.ImageToPdf;

public record ImageToPdfCommand(
    Memory<byte> File,
    DocumentPageSize DocumentPageSize,
    DocumentPageOrientation DocumentPageOrientation) 
    : IRequest<Result<Memory<byte>>>;