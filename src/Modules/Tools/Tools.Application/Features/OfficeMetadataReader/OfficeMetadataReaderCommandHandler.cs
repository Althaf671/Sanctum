using MediatR;
using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.OfficeMetadataReader;

internal sealed class OfficeMetadataReaderCommandHandler
    : IRequestHandler<OfficeMetadataReaderCommand, Result<OfficeMetadataDetail>>
{
    private readonly IOfficeMetadataReader _metadata;

    public OfficeMetadataReaderCommandHandler(IOfficeMetadataReader metadata)
    {
        _metadata = metadata;
    }

    public async Task<Result<OfficeMetadataDetail>> Handle(
        OfficeMetadataReaderCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await _metadata.ReadOfficeMetadata(
            request.File, 
            request.Type, 
            cancellationToken);

        return Result<OfficeMetadataDetail>.Success(result.Value!);
    }
}