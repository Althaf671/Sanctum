using MediatR;
using src.Modules.Tools.ToolsApplication.Common.Errors;
using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.ImageToPdf;

internal sealed class ImageToPdfCommandHandler
    : IRequestHandler<ImageToPdfCommand, Result<Memory<byte>>>
{
    private readonly IImageConverter _image;

    public ImageToPdfCommandHandler(IImageConverter image)
    {
        _image = image;
    }

    public async Task<Result<Memory<byte>>> Handle(
        ImageToPdfCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await _image.ImageToPdf(
            request.File,
            request.DocumentPageSize,
            request.DocumentPageOrientation,
            cancellationToken
        );
        if (result.IsFailure)
            return Result<Memory<byte>>.Failure(ToolsErrors.KonversiGagal("image", "pdf", ""));

        return Result<Memory<byte>>.Success(result.Value);
    }
}