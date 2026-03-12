using src.Modules.AcademicDomain.Enums;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.SharedKernel.Domain.Common;
using src.SharedKernel.Domain.Entities;
using static src.SharedKernel.Domain.Common.StringHelper.StringHelper;

namespace src.Modules.AcademicDomain.Entities;

public sealed class Jurusan : IAggregateRoot ,IEntity
{
    // Constant limits
    private const int _minStringInputLength = 10;

    private const int _maxStringInputLength = 30;

    // Properties
    public Guid Id { get; private set; }

    public string KodeJurusan { get; private set; } = string.Empty;

    public string NamaJurusan { get; private set; } = string.Empty;

    public string NamaFakultas { get; private set; } = string.Empty;

    public Jenjang Jenjang { get; private set; }

    public Akreditasi Akreditasi { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public DateTime CreatedAt { get; private set; } 


    // EF core private constructor
    private Jurusan() { }


    // Private constructor
    private Jurusan(
        string kodeJurusan,
        string namaJurusan,
        string namaFakultas,
        Jenjang jenjang,
        Akreditasi akreditasi)
    {
        Id = Guid.NewGuid();
        KodeJurusan = kodeJurusan;
        NamaJurusan = namaJurusan;
        NamaFakultas = namaFakultas;
        Jenjang = jenjang;
        Akreditasi = akreditasi;
        CreatedAt = DateTime.UtcNow; 
    }  

    // Factory
    public static Result<Jurusan> DaftarkanJurusan(
        string kodeJurusan,
        string namaJurusan,
        string namaFakultas,
        Jenjang jenjang,
        Akreditasi akreditasi)
    {
        var preValidate = PreValidate(kodeJurusan, namaJurusan, namaFakultas);
        if (preValidate.IsFailure)
            return Result<Jurusan>.Failure(preValidate.Error);

        var validation = ValidateInvariant(kodeJurusan, namaJurusan, namaFakultas);
        if (validation.IsFailure)
            return Result<Jurusan>.Failure(validation.Error);

        return Result<Jurusan>.Success(
            new Jurusan(
                kodeJurusan,
                namaJurusan,
                namaFakultas,
                jenjang,
                akreditasi
            ));
    }

    public Result RevisiInfoJurusan(
        string kodeJurusan,
        string namaJurusan,
        string namaFakultas,
        Jenjang jenjang,
        Akreditasi akreditasi)
    {
        var preValidate = PreValidate(kodeJurusan, namaJurusan, namaFakultas);
        if (preValidate.IsFailure)
            return Result<Jurusan>.Failure(preValidate.Error);

        var validation = ValidateInvariant(kodeJurusan, namaJurusan, namaFakultas);
        if (validation.IsFailure)
            return Result<Jurusan>.Failure(validation.Error);

        KodeJurusan = kodeJurusan;
        NamaJurusan = namaJurusan;
        NamaFakultas = namaFakultas;
        Jenjang = jenjang;
        Akreditasi = akreditasi;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    // Validate invariant  
    private static Result PreValidate(
        string kodeJurusan, 
        string namaJurusan, 
        string namaFakultas)
    {
        if (IsBlank(kodeJurusan))
            return Result.Failure(JurusanErrors.ValueRequired("Kode Jurusan"));

        if (IsBlank(namaJurusan))
            return Result.Failure(JurusanErrors.ValueRequired("Nama Jurusan"));

        if (IsBlank(namaFakultas))
            return Result.Failure(JurusanErrors.ValueRequired("Nama Fakultas"));

        return Result.Success;
    }

    private static Result ValidateInvariant(
        string kodeJurusan, 
        string namaJurusan, 
        string namaFakultas)
    {
        if (IsStringInputLengthOutOfRange(kodeJurusan, _minStringInputLength, _maxStringInputLength))
            return Result.Failure(JurusanErrors.InvalidInputLength("Kode Jurusan"));

        if (IsStringInputLengthOutOfRange(namaJurusan, _minStringInputLength, _maxStringInputLength))
            return Result.Failure(JurusanErrors.InvalidInputLength("Nama Jurusan"));

        if (IsStringInputLengthOutOfRange(namaFakultas, _minStringInputLength, _maxStringInputLength))
            return Result.Failure(JurusanErrors.InvalidInputLength("Nama Fakultas"));

        return Result.Success; 
    }
}