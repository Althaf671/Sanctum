using src.Domain.Common;

namespace src.Domain.ValueObjects;

public sealed class MasaKuliah : ValueObject
{
    public TimeSpan TahunAjaran { get; }

    public TimeSpan Durasi { get; }

    public override IEnumerable<object> GetAtomicValue()
    {
        yield return TahunAjaran;
        yield return Durasi;
    }

    // Factory
    public static Result<MasaKuliah> Create(
        TimeSpan tahunAjaran, 
        TimeSpan Durasi)
    {
        return Result<MasaKuliah>.Success(new MasaKuliah());
    }

    // Private constructor
    private MasaKuliah()
    {
        
    }

    // Validate invariant
}