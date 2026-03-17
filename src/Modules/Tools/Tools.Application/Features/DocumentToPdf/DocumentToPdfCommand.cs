using MediatR;
using src.Modules.Tools.ToolsApplication.Common.Enums;
using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.DocumentToPdf;

public record DocumentToPdfCommand(Memory<byte> File, DocumentExtensions FileExtensions) 
    : IRequest<Result<Memory<byte>>>;