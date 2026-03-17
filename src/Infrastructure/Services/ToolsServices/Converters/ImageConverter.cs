using System.Drawing;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using SixLabors.ImageSharp;
using src.Modules.Tools.ToolsApplication.Common.Enums;
using src.Modules.Tools.ToolsApplication.Common.Errors;
using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.SharedKernel.Domain.Common;

namespace src.Infrastructure.Services.ToolsServices.Converters;

public class ImageConverter : IImageConverter
{
    public async Task<Result<Memory<byte>>> ImageToPdf(
        Memory<byte> file, 
        DocumentPageSize documentPageSize,
        DocumentPageOrientation documentPageOrientation,
        CancellationToken cancellationToken)
    {
        // pdf sharp perlu stream jadi masukan file ke stream
        using var inputStream = new MemoryStream(file.ToArray());

        // output stream
        using var outputStream = new MemoryStream();

        try
        {
            // buat kertas kosong untuk menampung konten
            using var newblankDocument = new PdfDocument();

            // buat halaman
            var newPage = newblankDocument.AddPage();

            // load pdf drawer dari lib
            using var loadGraphic = XGraphics.FromPdfPage(newPage);

            // load input gambar dari stream di atas
            using var image = XImage.FromStream(inputStream);

            // atur size
            newPage.Size = MapPageSize(documentPageSize);
            newPage.Orientation = MapPageOrientation(documentPageOrientation);

            // gambar dengan lib
            loadGraphic.DrawImage(image, 0, 0);

            newblankDocument.Save(outputStream);

            var outputBytes = outputStream.ToArray();
            return Result<Memory<byte>>.Success(new Memory<byte>(outputBytes));
        }
        catch (Exception ex)
        {
            return Result<Memory<byte>>.Failure(ToolsErrors.KonversiGagal("image", "pdf", ex.Message));
        }
    }

    public async Task<Result<Memory<byte>>> ImageToWebp(
        Memory<byte> file, 
        CancellationToken cancellationToken)
    {
        using var inputStream = new MemoryStream(file.ToArray());

        using var outputStream = new MemoryStream();

        try
        {
            using var newInstance = Image.LoadAsync(inputStream, cancellationToken);

            var webp = newInstance.Result.SaveAsWebpAsync(outputStream, cancellationToken);

            var outputBytes = outputStream.ToArray();
            return Result<Memory<byte>>.Success(outputBytes);
        }
        catch (Exception ex)
        {
            return Result<Memory<byte>>
                .Failure(ToolsErrors.KonversiGagal("image", "webp" ,ex.Message));
        }
    }

    private static PageSize MapPageSize(DocumentPageSize size) => size switch
    {
        DocumentPageSize.A0 => PageSize.A0,
        DocumentPageSize.A1 => PageSize.A1,
        DocumentPageSize.A2 => PageSize.A2,
        DocumentPageSize.A3 => PageSize.A3,
        DocumentPageSize.A4 => PageSize.A4,
        DocumentPageSize.A5 => PageSize.A5,

        DocumentPageSize.B0 => PageSize.B0,
        DocumentPageSize.B1 => PageSize.B1,
        DocumentPageSize.B2 => PageSize.B2,
        DocumentPageSize.B3 => PageSize.B3,
        DocumentPageSize.B4 => PageSize.B4,
        DocumentPageSize.B5 => PageSize.B5,

        DocumentPageSize.Undefined => PageSize.Undefined,
        DocumentPageSize.Folio => PageSize.Folio,
        DocumentPageSize.Ledger => PageSize.Ledger,
        DocumentPageSize.Letter => PageSize.Letter,
        DocumentPageSize.Post => PageSize.Post,
        _ => PageSize.A4
    };

    private static PageOrientation MapPageOrientation(DocumentPageOrientation orientation) =>
    orientation switch
    {
        DocumentPageOrientation.Landscape => PageOrientation.Landscape,
        DocumentPageOrientation.Potrait => PageOrientation.Portrait,
        _ => PageOrientation.Portrait
    };
}