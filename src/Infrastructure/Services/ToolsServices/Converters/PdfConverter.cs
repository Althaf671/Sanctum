using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using src.Modules.Tools.ToolsApplication.Common.Enums;
using src.Modules.Tools.ToolsApplication.Common.Errors;
using src.Modules.Tools.ToolsApplication.Common.Interfaces;
using src.SharedKernel.Domain.Common;

namespace src.Infrastructure.Services.ToolsServices.Converters;

public class LibreOfficePdfConverter : IPdfConverter
{
    public async Task<Result<Memory<byte>>> DocumentToPdf(
        Memory<byte> file, 
        DocumentExtensions ogExt,
        string outExt,
        CancellationToken cancellationToken)
    {
        var originalExt = "." + ogExt.ToString().ToLowerInvariant();
        var outputExt = "." + outExt;

        // buat input path
        var inputPath = CreateInputPath(originalExt);
        
        // buat output path
        var outputPath = CreateOutputPath(inputPath, outputExt);

        try
        {
            await File.WriteAllBytesAsync(inputPath, file.ToArray(), cancellationToken);

            // Jalankan libre office binari dan tunggu hasil proses
            var process = ProcessLibreOfficeConverter(outputExt, inputPath);
            await process.WaitForExitAsync(cancellationToken);

            if (process.ExitCode != 0)
            {
                var error = await process.StandardError.ReadToEndAsync(cancellationToken);
                return Result<Memory<byte>>
                    .Failure(ToolsErrors.KonversiGagal(originalExt, outputExt, error));
            }

            if (!File.Exists(outputPath))
            {
                return Result<Memory<byte>>.Failure(ToolsErrors.OutputDirNotFound());
            }

            // buat bytes baru untuk di return
            var outputBytes = await File.ReadAllBytesAsync(outputPath, cancellationToken);
            return Result<Memory<byte>>.Success(new Memory<byte>(outputBytes));
        }
        finally
        {
            CleanUpPaths(inputPath, outputPath);
        }
    }

    private static string CreateInputPath(string originalExt) =>
        Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}{originalExt}");

    private static string CreateOutputPath(string inputPath, string extension) =>
        Path.ChangeExtension(inputPath, extension);
    

    private static Process ProcessLibreOfficeConverter(string outputExt, string inputPath)
    {
        // start dotnet process
        var process = new Process
        {
            // metadata process untuk mencari dan menjalankan libreoffice yang di dalam container
            StartInfo = new ProcessStartInfo
            {
                FileName = "libreoffice",
                Arguments = $"--headless --convert-to {outputExt.TrimStart('.')} \"{inputPath}\" --outdir \"{Path.GetTempPath()}\" ",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        process.Start();

        return process;
    }

    private static void CleanUpPaths(string inputPath, string outputPath)
    {
        if (File.Exists(inputPath))
            File.Delete(inputPath);

        if (File.Exists(outputPath))
            File.Delete(outputPath);
    }
}