using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.SharedKernel.Domain.Common;

namespace src.Infrastructure.Services.Converters;

public class ImageConverter : IImageConverter
{
    public Task<Result<byte[]>> JpgToPdf(byte[] file, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<byte[]>> JpgToWebp(byte[] file, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}