namespace src.Modules.Tools.ToolsApplication.Common.Model;

public record PdfMetadataDetail(
    PdfDocumentInfo PdfDocumentInfo,
    PdfSecurityInfo PdfSecurityInfo,
    PdfFileInfo PdfFileInfo,
    PdfPrivacyInfo PdfPrivacyInfo
);

public record PdfDocumentInfo(
    string Title,
    string Author,
    string Subject,
    string Keywords,
    string Creator,
    string Producer,
    string? Language,
    DateTime? CreationDate,
    DateTime? ModificationDate
);

public record PdfSecurityInfo(
    bool IsEncrypted,
    bool CanPrint,
    bool CanCopy,
    bool CanEdit,
    bool CanAnnotate,
    bool CanFillForm
);

public record PdfFileInfo(
    int PageCount,
    string PdfVersion,
    double FileSizeInKiloBytes
);

public record PdfPrivacyInfo(
    bool HasEmbeddedFiles
);

// todo: hasJs, HasHiddenText, hasHiddenLayer checker

public record OfficeMetadataDetail(
    OfficeDocumentInfo DocumentInfo,
    OfficeCreatorInfo CreatorInfo,
    OfficeDateInfo DateInfo,
    OfficeAppInfo AppInfo,
    OfficePrivacyInfo PrivacyInfo
);

public record OfficeDocumentInfo(
    string? Title,
    string? Subject,
    string? Description,
    string? Keywords,
    string? Category,
    string? Version
);

public record OfficeCreatorInfo(
    string? Creator,
    string? LastModifiedBy,
    string? Manager,
    string? Company
);

public record OfficeDateInfo(
    DateTime? CreatedAt,
    DateTime? ModifiedAt,
    DateTime? PrintedAt
);

public record OfficeAppInfo(
    string? Application,
    string? AppVersion,
    string? Template,
    int? Revision,
    int? TotalEditingTime,
    int? Pages,
    int? Words,
    int? Characters
);

public record OfficePrivacyInfo(
    bool HasCompanyInfo,
    bool HasPersonalInfo,
    bool HasEditHistory,
    bool HasPrintHistory,
    bool HasTemplate
);
