using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.ImageToWebp;

public record ImageToWebpCommand(Memory<byte> File) 
    : IRequest<Result<Memory<byte>>>;