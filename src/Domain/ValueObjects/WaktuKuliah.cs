using src.Domain.Common;
using src.Domain.Errors.ValueObjectErrors;

namespace src.Domain.ValueObjects;

public sealed class WaktuKuliah : ValueObject
{
    private static readonly TimeSpan MaxDurasi = TimeSpan.FromHours(4);

    public DateOnly Tanggal { get; } 

    public TimeOnly JamMulai { get; } 

    public TimeOnly JamBerakhir { get; }

    public DayOfWeek Hari => Tanggal.DayOfWeek;

    public TimeSpan Durasi => JamBerakhir - JamMulai;

    public override IEnumerable<object> GetAtomicValue()
    {
        yield return Tanggal;
        yield return JamMulai;
        yield return JamBerakhir;
    }

    // Factory
    public static Result<WaktuKuliah> Create(
        DateOnly tanggal, 
        TimeOnly jamMulai,
        TimeOnly jamBerakhir)
    {
        // validate invariant
        var validation = ValidateInvariant(jamMulai, jamBerakhir);
        if (validation.IsFailure)
            return Result<WaktuKuliah>.Failure(validation.Error);

        return Result<WaktuKuliah>.Success(
            new WaktuKuliah(tanggal, jamMulai, jamBerakhir));
    }

     private WaktuKuliah() { }

    // Private constrcutor
    private WaktuKuliah(
        DateOnly tanggal, 
        TimeOnly jamMulai, 
        TimeOnly jamBerakhir)
    {
        Tanggal = tanggal;
        JamMulai = jamMulai;
        JamBerakhir = jamBerakhir;
    }

    // Validate invariant
    private static Result ValidateInvariant(
        TimeOnly jamMulai,
        TimeOnly jamBerakhir)
    {
        // cek apakah jam di mulai di sebelum jam berakhir
        if (jamMulai >= jamBerakhir)
            return Result.Failure(WaktuKuliahErrors.InvalidRentangWaktu());

        // maksimal durasi adalah 4 jam
        if ((jamBerakhir - jamMulai) > MaxDurasi)
            return Result.Failure(WaktuKuliahErrors.ExceedBatasMaksDurasi());

        return Result.Success;
    }
}