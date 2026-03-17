using PdfSharp.Pdf.IO;
using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Infrastructure.Services.ToolsServices.Reader;
public class PdfMetadataReader : IPdfMetadataReader
{
    public async Task<Result<PdfMetadataDetail>> ReadPdfMetadata(Memory<byte> file)
    {
        using var inputStream = new MemoryStream(file.ToArray());

        using var pdfDocument = PdfReader.Open(inputStream, PdfDocumentOpenMode.Import);

        var DocumentInfo = new PdfDocumentInfo(
            Title: pdfDocument.Info.Title,
            Author: pdfDocument.Info.Author,
            Subject: pdfDocument.Info.Subject,
            Keywords: pdfDocument.Info.Keywords,
            Creator: pdfDocument.Info.Creator,
            Producer: pdfDocument.Info.Producer,
            Language: pdfDocument.Language,
            CreationDate: pdfDocument.Info.CreationDate,
            ModificationDate: pdfDocument.Info.ModificationDate
        );

        var SecurityInfo = new PdfSecurityInfo(
            IsEncrypted: pdfDocument.SecuritySettings.IsEncrypted,
            CanPrint: pdfDocument.SecuritySettings.PermitPrint,
            CanCopy: pdfDocument.SecuritySettings.PermitExtractContent,
            CanEdit: pdfDocument.SecuritySettings.PermitModifyDocument,
            CanAnnotate: pdfDocument.SecuritySettings.PermitAnnotations,
            CanFillForm: pdfDocument.SecuritySettings.PermitFormsFill
        );

        var FileInfo = new PdfFileInfo(
            PageCount: pdfDocument.PageCount,
            FileSizeInKiloBytes: Math.Round(file.Length / 1024.0, 2),
            PdfVersion: $"{pdfDocument.Version / 10}.{pdfDocument.Version % 10}"     
        );

        var PrivacyInfo = new PdfPrivacyInfo(
            HasEmbeddedFiles: pdfDocument.Internals.Catalog.Elements.ContainsKey("/Names")
        );

        return Result<PdfMetadataDetail>.Success(
            new PdfMetadataDetail(
                DocumentInfo,
                SecurityInfo,
                FileInfo,
                PrivacyInfo
            )
        );
    }

}