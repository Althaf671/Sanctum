using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using src.Modules.Tools.ToolsApplication.Features.DocumentToPdf;
using src.Modules.Tools.ToolsApplication.Common.Enums;
using src.Modules.Tools.ToolsApplication.Features.ImageToPdf;
using src.Modules.Tools.ToolsApplication.Features.ImageToWebp;
using src.Modules.Tools.ToolsApplication.Common.Model;
using src.Modules.Tools.ToolsApplication.Features.PdfMetadataReader;
using System.Runtime.CompilerServices;
using src.Modules.Tools.ToolsApplication.Features.ImageMetadataReader;
using src.Modules.Tools.ToolsApplication.Features.OfficeMetadataReader;

namespace src.Presentation.Api.ToolsController;

[ApiController]
[Route("api/[controller]")]
public class ToolsController : ControllerBase
{
    private readonly ISender _sender;

    public ToolsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("document-to-pdf")]
    public async Task<IActionResult> DocumentToPdf(
        IFormFile file,
        DocumentExtensions docExt,
        CancellationToken cancellationToken)
    {
        using var memstream = new MemoryStream();

        await file.CopyToAsync(memstream, cancellationToken);

        var memory = new Memory<byte>(memstream.ToArray());

        var res = await _sender.Send(
            new DocumentToPdfCommand(memory, docExt), cancellationToken
        );

        return res.IsFailure
            ? BadRequest(res.Error)
            : File(
                res.Value.ToArray(),
                "application/pdf", 
                $"{Path.GetFileNameWithoutExtension(file.FileName)}.pdf");
    }

    [HttpPost("image-to-pdf")]
    public async Task<IActionResult> ImageToPdf(
        IFormFile file,
        DocumentPageSize pageSize,
        DocumentPageOrientation pageOrientation,
        CancellationToken cancellationToken
    )
    {
        using var memstream = new MemoryStream();

        await file.CopyToAsync(memstream, cancellationToken);

        var memory = new Memory<byte>(memstream.ToArray());

        var res = await _sender.Send(
            new ImageToPdfCommand(memory, pageSize, pageOrientation), 
            cancellationToken
        );

        return res.IsFailure
            ? BadRequest(res.Error)
            : File(
                res.Value.ToArray(),
                "application/pdf",
                $"{Path.GetFileNameWithoutExtension(file.FileName)}.pdf");
    }

    [HttpPost("image-to-webp")]
    public async Task<IActionResult> ImageToWebp(
        IFormFile file,
        CancellationToken cancellationToken
    )
    {
        using var memstream = new MemoryStream();

        await file.CopyToAsync(memstream, cancellationToken);

        var memory = new Memory<byte>(memstream.ToArray());

        var res = await _sender.Send(
            new ImageToWebpCommand(memory), cancellationToken
        );

        return res.IsFailure
            ? BadRequest(res.Error)
            : File(
                res.Value.ToArray(),
                "application/webp",
                $"{Path.GetFileNameWithoutExtension(file.FileName)}.webp"
            );
    }

    // butuh modifikasi menjadi universal document metadata reader, 2 mode:
    // plain json output & smart json output
    [HttpPost("read-pdf-metadata")]
    public async Task<IActionResult> ReadPdfMetadata(
        IFormFile file,
        CancellationToken cancellationToken)
    {
        using var memstream = new MemoryStream();

        await file.CopyToAsync(memstream, cancellationToken);

        var memory = new Memory<byte>(memstream.ToArray());

        var res = await _sender.Send(new PdfMetadataReaderCommand(memory), cancellationToken);

        return res.IsFailure
            ? BadRequest()
            : Ok(new
            {
                filename = file.FileName,
                metadata = res.Value
            });
    }

    [HttpPost("read-office-metadata")]
    public async Task<IActionResult> ReadOfficeMetadata(
        IFormFile file,
        OfficeDocumentType type,
        CancellationToken cancellationToken)
    {
        using var memstream = new MemoryStream();

        await file.CopyToAsync(memstream, cancellationToken);

        var memory = new Memory<byte>(memstream.ToArray());

        var res = await _sender.Send(new OfficeMetadataReaderCommand(memory, type), cancellationToken);

        return res.IsFailure
            ? BadRequest()
            : Ok(new
            {
                filename = file.FileName,
                metadata = res.Value
            });
    }

    [HttpPost("read-image-metadata")]
    public async Task<IActionResult> ReadImageMetadata(
        IFormFile file,
        CancellationToken cancellationToken)
    {
        using var memstream = new MemoryStream();

        await file.CopyToAsync(memstream, cancellationToken);

        var memory = new Memory<byte>(memstream.ToArray());

        var res = await _sender.Send(
            new ImageMetadataReaderCommand(memory, cancellationToken), 
            cancellationToken);

        return Ok(new
        {
            filename = file.FileName,
            metadata = res.Value
        });
    }

    // sekalian remover semua dokumen dengan openxml
    // [HttpPost("remove-pdf-metadata")]
    // public async Task<IActionResult> RemovePdfMetadata()
    // {
        
    // }

    // [HttpPost("remove-image-metadata")]
    // public async Task<IActionResult> RemoveImageMetadata()
    // {
        
    // }
}