using src.Domain.Common;
using src.Domain.Entities;
using src.Domain.Enums;
using src.Domain.Errors.ValueObjectErrors;

namespace src.Domain.ValueObjects;

public sealed class MasaKuliah : ValueObject
{
    private const int February =  2;

    private const int May = 5;

    private const int August = 8;

    private const int December = 12;

    public DateOnly Start { get; private set; }

    public DateOnly End { get; private set; }

    public TimeSpan Durasi => TimeSpan.FromDays(End.DayNumber - Start.DayNumber);

    public override IEnumerable<object> GetAtomicValue()
    {
        yield return Start;
        yield return End;
        yield return Durasi;
    }

    // Factory
    public static Result<MasaKuliah> Create(
        SemesterPeriod semesterPeriod, 
        int tahun)
    {
        // Get semester type start dan end date 
        var result = GetSemesterStartAndEndMonth(semesterPeriod, tahun);
        if (result.IsFailure)
            return Result<MasaKuliah>.Failure(result.Error);

        // validate invariant
        var validation = ValidateInvariant(result.Value.Start, result.Value.End);
        if (validation.IsFailure)
            return Result<MasaKuliah>.Failure(validation.Error);

        return Result<MasaKuliah>.Success(new MasaKuliah(result.Value.Start, result.Value.End));
    }

    // Private constructor
    private MasaKuliah(DateOnly start, DateOnly end)
    {
        Start = start;
        End = end;
    }

    // Validate invariant
    private static Result ValidateInvariant(DateOnly start, DateOnly end)
    {
        // cek apakah waktu mulai sebelum waktu berakhir
        if (start >= end)
            return Result.Failure(MasaKuliahErrors.CantStartAfterEnd());

        return Result.Success;
    }

    // Convert tahun ajaran into valid start and end month
    private static Result<(DateOnly Start, DateOnly End)> GetSemesterStartAndEndMonth(
        SemesterPeriod semesterPeriod, 
        int tahun)
    {
        if (semesterPeriod.Equals(SemesterPeriod.GANJIL))
        {
            var start = new DateOnly(tahun, August, 1);

            var end = new DateOnly(tahun, December, 15);

            return Result<(DateOnly, DateOnly)>.Success((start, end));
        }
        else if (semesterPeriod.Equals(SemesterPeriod.GENAP))
        {
            var start = new DateOnly(tahun + 1, February, 1); 

            var end = new DateOnly(tahun + 1, May, 31); 

            return Result<(DateOnly, DateOnly)>.Success((start, end));
        }
        else
        {
            return Result<(DateOnly, DateOnly)>.Failure(MasaKuliahErrors.InvalidSemesterPeriod());
        }
    }
}

