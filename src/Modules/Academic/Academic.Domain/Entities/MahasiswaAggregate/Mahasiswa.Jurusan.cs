using src.Modules.AcademicDomain.Enums;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.SharedKernel.Domain.Common;
using static src.SharedKernel.Domain.Common.StringHelper.StringHelper;

namespace src.Modules.AcademicDomain.Entities.MahasiswaAggregate;

public sealed partial class Mahasiswa 
{
    // Constant limits
    private const int MinPanjangNamaJurusan = 10;

    private const int MaxPanjangNamaJurusan = 30;

    private const int MinPanjangKodeJurusan = 5;

    private const int MaxPanjangKodeJurusan = 20;

    public Result RevisiInfoJurusan(
        string kodeJurusan,
        string namaJurusan,
        Jenjang jenjang)
    {
        var required = ValidateJurusanRequiredFields(kodeJurusan, namaJurusan);
        if (required.IsFailure)
            return Result.Failure(required.Error);

        var validation = ValidateJurusanInvariant(kodeJurusan, namaJurusan);
        if (validation.IsFailure)
            return Result.Failure(validation.Error);

        KodeJurusan = kodeJurusan;
        NamaJurusan = namaJurusan;
        Jenjang = jenjang;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    public Result HapusInfoJurusan()
    {
        NamaJurusan = string.Empty;
        KodeJurusan = string.Empty;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    // Validate invariant  
    private static Result ValidateJurusanRequiredFields(
        string namaJurusan,
        string kodeJurusan)
    {
        if (IsBlank(kodeJurusan))
            return Result.Failure(JurusanErrors.ValueRequired("Kode Jurusan"));

        if (IsBlank(namaJurusan))
            return Result.Failure(JurusanErrors.ValueRequired("Nama Jurusan"));

        return Result.Success;
    }

    private static Result ValidateJurusanInvariant(
        string kodeJurusan, 
        string namaJurusan)
    {
        if (IsStringInputLengthOutOfRange(kodeJurusan, MinPanjangKodeJurusan, MaxPanjangKodeJurusan))
            return Result.Failure(JurusanErrors.InvalidInputLength("Kode Jurusan"));

        if (IsStringInputLengthOutOfRange(namaJurusan, MinPanjangNamaJurusan, MaxPanjangNamaJurusan))
            return Result.Failure(JurusanErrors.InvalidInputLength("Nama Jurusan"));

        return Result.Success; 
    }
}