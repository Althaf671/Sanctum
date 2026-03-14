using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Common.Interfaces;

public interface IImageConverter
{
   Task<Result<byte[]>> JpgToPdf(byte[] file, CancellationToken cancellationToken);

   Task<Result<byte[]>> JpgToWebp(byte[] file, CancellationToken cancellationToken);
}