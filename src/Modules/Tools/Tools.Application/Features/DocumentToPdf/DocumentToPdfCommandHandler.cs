using MediatR;
using src.Modules.Tools.ToolsApplication.Common.Enums;
using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Features.DocumentToPdf;

internal sealed class DocumentToPdfCommandHandler
    : IRequestHandler<DocumentToPdfCommand, Result<Memory<byte>>>
{
    private readonly IPdfConverter _document;

    private readonly IPdfMetadataReader _metadata;

    public DocumentToPdfCommandHandler(
        IPdfConverter document,
        IPdfMetadataReader metadata)
    {
        _document = document;
        _metadata = metadata;
    }

    public async Task<Result<Memory<byte>>> Handle(
        DocumentToPdfCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await _document.DocumentToPdf(
            request.File, 
            request.FileExtensions, 
            DocumentExtensions.Pdf.ToString().ToLowerInvariant(), 
            cancellationToken);
        if (result.IsFailure)
            return Result<Memory<byte>>.Failure(result.Error);

        return Result<Memory<byte>>.Success(result.Value);
    }
}