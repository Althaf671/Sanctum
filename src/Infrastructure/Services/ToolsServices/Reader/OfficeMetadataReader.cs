using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using src.Modules.Tools.ToolsApplication.Common.Enums;
using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.Modules.Tools.ToolsApplication.Common.Model;
using src.SharedKernel.Domain.Common;

namespace src.Infrastructure.Services.ToolsServices.Reader;

public class OfficeMetadataReader : IOfficeMetadataReader
{
    public async Task<Result<OfficeMetadataDetail>> ReadOfficeMetadata(
        Memory<byte> file, 
        OfficeDocumentType documentType,
        CancellationToken cancellationToken)
    {
        using var inputStream = new MemoryStream(file.ToArray());
        
        var result = documentType switch
        {
            OfficeDocumentType.Xlxs => SpreadSheetProcessor(inputStream),
            OfficeDocumentType.Docx => WordProcessor(inputStream),
            OfficeDocumentType.Pptx => PresentationProcessor(inputStream),
            _ => throw new InvalidOperationException("Operation read office metadata failed.")
        };
        
        return Result<OfficeMetadataDetail>.Success(result);
    }

    private static OfficeMetadataDetail SpreadSheetProcessor(MemoryStream inputStream)
    {
        using var spreadsheet = SpreadsheetDocument.Open(inputStream, false);

        var core = spreadsheet.CoreFilePropertiesPart?.CoreFileProperties;
        var extended = spreadsheet.ExtendedFilePropertiesPart?.Properties;

        var documentInfo = new OfficeDocumentInfo(
            Title:  core?.Title?.ToString(),
            Subject: core?.Subject?.ToString(),
            Description: core?.Description?.ToString(),
            Keywords: core?.Keywords?.ToString(),
            Category: core?.Category?.ToString(),
            Version: core?.Version
        );

        var creatorInfo = new OfficeCreatorInfo(
            Creator: core?.Creator?.ToString(),
            LastModifiedBy: core?.LastModifiedBy?.ToString(),
            Company: extended?.Company?.Text,
            Manager: extended?.Manager?.Text
        );

        var dateInfo = new OfficeDateInfo(
            CreatedAt: DateTime.TryParse(core?.Created?.ToString(), out var c) ? c : null,
            ModifiedAt: DateTime.TryParse(core?.Modified?.ToString(), out var m) ? m : null,
            PrintedAt: DateTime.TryParse(core?.LastPrinted?.ToString(), out var p) ? p : null
        );

        var appInfo = new OfficeAppInfo(
            Application: extended?.Application?.Text,
            AppVersion: extended?.ApplicationVersion?.Text,
            Template: extended?.Template?.Text,
            Revision: int.TryParse(core?.Revision?.ToString(), out var r) ? r : null,
            TotalEditingTime: int.TryParse(extended?.TotalTime?.Text, out var t) ? t : null,
            Pages: int.TryParse(extended?.Pages?.Text, out var pg) ? pg : null,
            Words: int.TryParse(extended?.Words?.Text, out var w) ? w : null,
            Characters: extended?.Words?.Text.Length
        );

        var privacyInfo = new OfficePrivacyInfo(
            HasCompanyInfo:  !string.IsNullOrEmpty(extended?.Company?.Text),
            HasPersonalInfo: !string.IsNullOrEmpty(core?.Creator?.ToString()),
            HasEditHistory:  int.TryParse(core?.Revision?.ToString(), out var rev) && rev > 1,
            HasPrintHistory: core?.LastPrinted != null,
            HasTemplate:     !string.IsNullOrEmpty(extended?.Template?.Text)
        );

        return new OfficeMetadataDetail(documentInfo, creatorInfo, dateInfo, appInfo, privacyInfo);
    }

    private static OfficeMetadataDetail WordProcessor(MemoryStream inputStream)
    {
        using var word = WordprocessingDocument.Open(inputStream, false);

        var core = word.CoreFilePropertiesPart?.CoreFileProperties;
        var extended = word.ExtendedFilePropertiesPart?.Properties;

        var documentInfo = new OfficeDocumentInfo(
            Title:  core?.Title?.ToString(),
            Subject: core?.Subject?.ToString(),
            Description: core?.Description?.ToString(),
            Keywords: core?.Keywords?.ToString(),
            Category: core?.Category?.ToString(),
            Version: core?.Version
        );

        var creatorInfo = new OfficeCreatorInfo(
            Creator: core?.Creator?.ToString(),
            LastModifiedBy: core?.LastModifiedBy?.ToString(),
            Company: extended?.Company?.Text,
            Manager: extended?.Manager?.Text
        );

        var dateInfo = new OfficeDateInfo(
            CreatedAt: DateTime.TryParse(core?.Created?.ToString(), out var c) ? c : null,
            ModifiedAt: DateTime.TryParse(core?.Modified?.ToString(), out var m) ? m : null,
            PrintedAt: DateTime.TryParse(core?.LastPrinted?.ToString(), out var p) ? p : null
        );

        var appInfo = new OfficeAppInfo(
            Application: extended?.Application?.Text,
            AppVersion: extended?.ApplicationVersion?.Text,
            Template: extended?.Template?.Text,
            Revision: int.TryParse(core?.Revision?.ToString(), out var r) ? r : null,
            TotalEditingTime: int.TryParse(extended?.TotalTime?.Text, out var t) ? t : null,
            Pages: int.TryParse(extended?.Pages?.Text, out var pg) ? pg : null,
            Words: int.TryParse(extended?.Words?.Text, out var w) ? w : null,
            Characters: extended?.Words?.Text.Length
        );

        var privacyInfo = new OfficePrivacyInfo(
            HasCompanyInfo:  !string.IsNullOrEmpty(extended?.Company?.Text),
            HasPersonalInfo: !string.IsNullOrEmpty(core?.Creator?.ToString()),
            HasEditHistory:  int.TryParse(core?.Revision?.ToString(), out var rev) && rev > 1,
            HasPrintHistory: core?.LastPrinted != null,
            HasTemplate:     !string.IsNullOrEmpty(extended?.Template?.Text)
        );

        return new OfficeMetadataDetail(documentInfo, creatorInfo, dateInfo, appInfo, privacyInfo);
    }

    private static OfficeMetadataDetail PresentationProcessor(MemoryStream inputStream)
    {
        using var presentation = PresentationDocument.Open(inputStream, false);

        var core = presentation.CoreFilePropertiesPart?.CoreFileProperties;
        var extended = presentation.ExtendedFilePropertiesPart?.Properties;

        var documentInfo = new OfficeDocumentInfo(
            Title:  core?.Title?.ToString(),
            Subject: core?.Subject?.ToString(),
            Description: core?.Description?.ToString(),
            Keywords: core?.Keywords?.ToString(),
            Category: core?.Category?.ToString(),
            Version: core?.Version
        );

        var creatorInfo = new OfficeCreatorInfo(
            Creator: core?.Creator?.ToString(),
            LastModifiedBy: core?.LastModifiedBy?.ToString(),
            Company: extended?.Company?.Text,
            Manager: extended?.Manager?.Text
        );

        var dateInfo = new OfficeDateInfo(
            CreatedAt: DateTime.TryParse(core?.Created?.ToString(), out var c) ? c : null,
            ModifiedAt: DateTime.TryParse(core?.Modified?.ToString(), out var m) ? m : null,
            PrintedAt: DateTime.TryParse(core?.LastPrinted?.ToString(), out var p) ? p : null
        );

        var appInfo = new OfficeAppInfo(
            Application: extended?.Application?.Text,
            AppVersion: extended?.ApplicationVersion?.Text,
            Template: extended?.Template?.Text,
            Revision: int.TryParse(core?.Revision?.ToString(), out var r) ? r : null,
            TotalEditingTime: int.TryParse(extended?.TotalTime?.Text, out var t) ? t : null,
            Pages: int.TryParse(extended?.Pages?.Text, out var pg) ? pg : null,
            Words: int.TryParse(extended?.Words?.Text, out var w) ? w : null,
            Characters: int.TryParse(extended?.Characters?.Text, out var ch) ? ch : null
        );

        var privacyInfo = new OfficePrivacyInfo(
            HasCompanyInfo:  !string.IsNullOrEmpty(extended?.Company?.Text),
            HasPersonalInfo: !string.IsNullOrEmpty(core?.Creator?.ToString()),
            HasEditHistory:  int.TryParse(core?.Revision?.ToString(), out var rev) && rev > 1,
            HasPrintHistory: core?.LastPrinted != null,
            HasTemplate:     !string.IsNullOrEmpty(extended?.Template?.Text)
        );

        return new OfficeMetadataDetail(documentInfo, creatorInfo, dateInfo, appInfo, privacyInfo);
    }
}