using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;
using src.SharedKernel.Domain.ValueObjects;
using static src.SharedKernel.Domain.Common.StringHelper.StringHelper;

namespace src.Modules.AcademicDomain.Entities.MahasiswaAggregate;

public sealed partial class Mahasiswa 
{
    // Konstanta
    private const int MaxPanjangNamaUniversitas = 50;

    private const int MinPanjangNamaUniversitas = 10;

    private const int MaxPanjangSingkatanUniversitas = 20;

    private const int MinPanjangSingkatanUniversitas = 2;

    public Result RevisiInfoUniversitas(
        string nama,
        KodeUniversitas kode,
        string singkatan,
        Url link)
    {
        var required = ValidateUniversitasRequiredFields(nama, singkatan);
        if (required.IsFailure)
            return Result.Failure(required.Error);

        var normalizeNama = NormalizeNama(nama);

        var normalizeSingkatan = NormalizeSingkatan(singkatan);

        var validation = ValidateUniversitasInvariant(normalizeNama, normalizeSingkatan);
        if (validation.IsFailure)
            return Result.Failure(validation.Error);

        NamaUniversitas = normalizeNama;
        KodeUniversitas = kode;
        SingkatanUniversitas = normalizeSingkatan;
        LinkWebUniversitas = link;
        UpdatedAt = DateTime.UtcNow;
        
        return Result.Success;
    }

    public Result HapusInfoUniversitas()
    {
        NamaUniversitas = string.Empty;
        SingkatanUniversitas = string.Empty;
        KodeUniversitas = null;
        LinkWebUniversitas = null;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    private static Result ValidateUniversitasRequiredFields(string nama, string singkatan)
    {
        if (IsBlank(nama))
            return Result.Failure(UniversitasErrors.ValueRequired("Nama"));

        if (IsBlank(singkatan))
            return Result.Failure(UniversitasErrors.ValueRequired("Singkatan"));

        return Result.Success;
    }

    private static Result ValidateUniversitasInvariant(string nama, string singkatan)
    {
        if (IsStringInputLengthOutOfRange(
            nama, MinPanjangNamaUniversitas, MaxPanjangNamaUniversitas))
            return Result.Failure(UniversitasErrors.InvalidInputLength(
                "Nama", MinPanjangNamaUniversitas, MaxPanjangNamaUniversitas));

        if (IsStringInputLengthOutOfRange(
            singkatan, MinPanjangSingkatanUniversitas, MaxPanjangSingkatanUniversitas))
            return Result.Failure(UniversitasErrors.InvalidInputLength(
                "Singkatan", MinPanjangSingkatanUniversitas, MaxPanjangSingkatanUniversitas));

        return Result.Success;
    }
}