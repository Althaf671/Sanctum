using src.SharedKernel.Domain.Common;

namespace src.Modules.Tools.ToolsApplication.Common.Errors;
public static class ToolsErrors
{
    private static readonly string _domain = "";

    public static Error KonversiGagal(
        string originalExt, 
        string outputExt, 
        string detailedError)
    {
        return new Error(
            "ToolsErrors.KonversiGagal",
            $"Gagal mengkonversi file dengan format {originalExt} ke {outputExt} dengan detail: {detailedError}",
            _domain
        );
    }

    public static Error OutputDirNotFound()
    {
        return new Error(
            "ToolsErrors.OutputDirNotFound",
            "Output direction tidak ditemukan",
            _domain
        );
    }
}