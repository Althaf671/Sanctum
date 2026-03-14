using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.ExcelToPdf;

public record ExcelToPdfCommand(byte[] File) : IRequest<Result<byte[]>>;