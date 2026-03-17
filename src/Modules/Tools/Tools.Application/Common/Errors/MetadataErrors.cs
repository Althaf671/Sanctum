using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Common.Errors;

public static class MetadataErrors
{
    public static Error PdfMetadataIsNull(string domain)
    {
        return new Error(
            "MetadataErrors.PdfMetadataIsNull",
            "Pdf metadata bernilai null",
            domain
        );
    }
}