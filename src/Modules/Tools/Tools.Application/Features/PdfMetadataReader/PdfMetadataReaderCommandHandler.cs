using MediatR;
using src.Modules.Tools.ToolsApplication.Common.Errors;
using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.PdfMetadataReader;

internal sealed class PdfMetadataReaderCommandHandler
    : IRequestHandler<PdfMetadataReaderCommand, Result<PdfMetadataDetail>>
{
    private readonly IPdfMetadataReader _metadata;

    public PdfMetadataReaderCommandHandler(IPdfMetadataReader metadata)
    {
        _metadata = metadata;
    }

    public async Task<Result<PdfMetadataDetail>> Handle(
        PdfMetadataReaderCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await _metadata.ReadPdfMetadata(request.File);
        if (result is null)
            return Result<PdfMetadataDetail>
                .Failure(MetadataErrors.PdfMetadataIsNull(nameof(PdfMetadataReader)));

        return Result<PdfMetadataDetail>.Success(result.Value!);

    }
}