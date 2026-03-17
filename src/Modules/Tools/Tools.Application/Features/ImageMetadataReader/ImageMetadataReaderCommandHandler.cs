using MediatR;
using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.ImageMetadataReader;

internal sealed class ImageMetadataReaderCommandHandler
    : IRequestHandler<ImageMetadataReaderCommand, Result<ImageMasterMetadataDetail>>
{
    private readonly IImageMetadataReader _metadata;

    public ImageMetadataReaderCommandHandler(IImageMetadataReader metadata)
    {
        _metadata = metadata;
    }

    public async Task<Result<ImageMasterMetadataDetail>> Handle(
        ImageMetadataReaderCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await _metadata.ReadImageMetadata(request.File, cancellationToken);

        return Result<ImageMasterMetadataDetail>.Success(result.Value!);
    }
}