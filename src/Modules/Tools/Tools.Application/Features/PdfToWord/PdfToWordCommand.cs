using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.PdfToWord;

public record PdfToWordCommand(byte[] File) : IRequest<Result<byte[]>>;