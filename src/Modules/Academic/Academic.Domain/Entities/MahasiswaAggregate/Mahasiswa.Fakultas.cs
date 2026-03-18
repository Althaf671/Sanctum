using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;
using static src.SharedKernel.Domain.Common.StringHelper.StringHelper;

namespace src.Modules.AcademicDomain.Entities.MahasiswaAggregate;

public sealed partial class Mahasiswa 
{
    // Konstanta
    private const int MaxPanjangNamaFakultas = 50;

    private const int MinPanjangNamaFakultas = 10;

    private const int MaxPanjangSingkatanFakultas = 15;

    private const int MinPanjangSingkatanFakultas = 2;

    public Result RevisiInfoFakultas(
        string nama,
        KodeFakultas kode,
        string singkatan)
    {
        var required = ValidateFakultasRequiredFields(nama, singkatan);
        if (required.IsFailure)
            return Result.Failure(required.Error);

        var normalizeNama = NormalizeNama(nama);

        var normalizeSingkatan = NormalizeSingkatan(singkatan);

        var validation = ValidateFakultasInvariant(normalizeNama, normalizeSingkatan);
        if (validation.IsFailure)
            return Result.Failure(validation.Error);

        NamaFakultas = normalizeNama;
        KodeFakultas = kode;
        SingkatanFakultas = normalizeSingkatan;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    public Result HapusInfoFakultas()
    {
        NamaFakultas = string.Empty;
        SingkatanFakultas = string.Empty;
        KodeFakultas = null;
        LinkiLearn = null;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    private static Result ValidateFakultasRequiredFields(string nama, string singkatan)
    {
        if (IsBlank(nama))
            return Result.Failure(FakultasErrors.ValueRequired("Nama"));

        if (IsBlank(singkatan))
            return Result.Failure(FakultasErrors.ValueRequired("Singkatan"));

        return Result.Success;
    }

    private static Result ValidateFakultasInvariant(string nama, string singkatan)
    {
        if (IsStringInputLengthOutOfRange(nama, MinPanjangNamaFakultas, MaxPanjangNamaFakultas))
            return Result.Failure(FakultasErrors
                .InvalidInputLength("Nama", MinPanjangNamaFakultas, MaxPanjangNamaFakultas));

        if (IsStringInputLengthOutOfRange(singkatan, MinPanjangSingkatanFakultas, MaxPanjangSingkatanFakultas))
            return Result.Failure(FakultasErrors
                .InvalidInputLength("Singkatan", MinPanjangSingkatanFakultas, MaxPanjangSingkatanFakultas));

        return Result.Success;
    }
}