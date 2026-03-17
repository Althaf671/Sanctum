using MediatR;
using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.ImageToWebp;

internal sealed class ImageToWebpCommandHandler
    : IRequestHandler<ImageToWebpCommand, Result<Memory<byte>>>
{
    private readonly IImageConverter _image;

    public ImageToWebpCommandHandler(IImageConverter image)
    {
        _image = image;
    }

    public async Task<Result<Memory<byte>>> Handle(
        ImageToWebpCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await _image.ImageToWebp(
            request.File,
            cancellationToken
        );
        if (result.IsFailure)   
            return Result<Memory<byte>>.Failure(result.Error);

        return Result<Memory<byte>>.Success(result.Value);
    }
}