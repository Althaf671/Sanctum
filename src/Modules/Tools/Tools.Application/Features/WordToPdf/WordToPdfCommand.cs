using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.WordToPdf;

public record WordToPdfCommand(byte[] File) : IRequest<Result<byte[]>>;