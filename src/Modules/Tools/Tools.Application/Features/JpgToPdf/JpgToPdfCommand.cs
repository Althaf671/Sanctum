using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.JpgToPdf;

public record JpgToPdfCommand(byte[] File) : IRequest<Result<byte[]>>;