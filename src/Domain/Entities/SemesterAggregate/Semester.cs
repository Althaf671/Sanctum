using src.Domain.Common;
using src.Domain.Errors.EntityErrors;
using src.Domain.ValueObjects;
using static src.Domain.Common.StringHelper.StringHelper;

namespace src.Domain.Entities.SemesterAggregate;

public sealed class Semester : IAggregateRoot, IEntity
{
    // Limit constants
    private const int _minTahunAjaranLength = 10;

    private const int _maxTahunAjaranLength = 20;

    // Properties
    public Guid Id { get; private set; }

    public MasaKuliah MasaKuliah { get; private set; } = null!;

    public string TahunAjaran { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; }


    // EF core private constructor
    private Semester() { }

    // Private constructor
    private Semester(
        MasaKuliah masaKuliah, 
        string tahunAjaran)
    {
        Id = Guid.NewGuid();
        MasaKuliah = masaKuliah;
        TahunAjaran = tahunAjaran;
        CreatedAt = DateTime.UtcNow;
    }

    // Factory
    public static Result<Semester> Create(MasaKuliah masaKuliah, string tahunAjaran)
    {
        if (IsBlank(tahunAjaran))
            return Result<Semester>.Failure(SemesterErrors.ValueRequired("Tahun Ajaran"));

        var validation = ValidateInvariant(tahunAjaran);
        if (validation.IsFailure)
            return Result<Semester>.Failure(validation.Error);

        return Result<Semester>.Success(new Semester(masaKuliah, tahunAjaran));
    }

    public Result RevisiInfoSemester(MasaKuliah masaKuliah, string tahunAjaran)
    {
        if (IsBlank(tahunAjaran))
            return Result<Semester>.Failure(SemesterErrors.ValueRequired("Tahun Ajaran"));

        var validation = ValidateInvariant(tahunAjaran);
        if (validation.IsFailure)
            return Result<Semester>.Failure(validation.Error);

        MasaKuliah = masaKuliah;
        TahunAjaran = tahunAjaran;

        return Result.Success;
    }

    // Validate Invariant
    private static Result ValidateInvariant(string tahunAjaran)
    {
        if (IsStringInputLengthOutOfRange(tahunAjaran, _minTahunAjaranLength, _maxTahunAjaranLength))
            return Result.Failure(SemesterErrors.InvalidTahunAjaranLength());

        return Result.Success;
    }
}