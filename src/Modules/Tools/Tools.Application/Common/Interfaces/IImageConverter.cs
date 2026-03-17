using src.Modules.Tools.ToolsApplication.Common.Enums;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Common.Interfaces;

public interface IImageConverter
{
   // pdfsharp
   Task<Result<Memory<byte>>> ImageToPdf(
      Memory<byte> file, 
      DocumentPageSize pageSize,
      DocumentPageOrientation pageOrientation,
      CancellationToken cancellationToken);

   // imagesharp
   Task<Result<Memory<byte>>> ImageToWebp(
      Memory<byte> file, CancellationToken cancellationToken);
}