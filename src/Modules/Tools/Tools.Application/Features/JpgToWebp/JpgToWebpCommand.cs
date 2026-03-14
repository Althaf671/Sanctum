using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.JpgToWebp;

public record JpgToWebpCommand(byte[] File) : IRequest<Result<byte[]>>;