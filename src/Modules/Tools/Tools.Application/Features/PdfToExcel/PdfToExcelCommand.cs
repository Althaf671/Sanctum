using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.PdfToExcel;

public record PdfToExcelCommand(byte[] File) : IRequest<Result<byte[]>>;