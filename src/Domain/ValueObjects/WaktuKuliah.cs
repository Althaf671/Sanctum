using src.Domain.Common;

namespace src.Domain.ValueObjects;

public sealed class WaktuKuliah : ValueObject
{
    public DayOfWeek Hari { get; }

    public DateTime Tanggal { get; } 

    public TimeSpan Jam { get; } 

    public TimeSpan Durasi { get; }

    public override IEnumerable<object> GetAtomicValue()
    {
        yield return Hari;
        yield return Tanggal;
        yield return Jam;
        yield return Durasi;
    }

    // Factory
    public static Result<WaktuKuliah> Create(
        DateTime tanggal, 
        TimeSpan jam, 
        TimeSpan durasi)
    {
        return Result<WaktuKuliah>.Success(new WaktuKuliah());
    }

    // Private constrcutor
    private WaktuKuliah()
    {
        
    }

    // Validate invariant
}