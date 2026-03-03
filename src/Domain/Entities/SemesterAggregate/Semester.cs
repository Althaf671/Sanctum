using src.Domain.Common;
using src.Domain.ValueObjects;

namespace src.Domain.Entities.SemesterAggregate;

public sealed class Semester : IAggregateRoot, IEntity
{
    public Guid Id { get; private set; }

    public MasaKuliah MasaKuliah { get; private set; }

    public string TahunAjaran { get; private set; }

    public DateTime CreatedAt { get; private set; }

    // Foreign Key
    public Guid MataKuliahId { get; private set; }

    private Semester() { }

    // Factory
    public static Result<Semester> Create()
    {
        return Result<Semester>.Success();
    }

    // Private constructor
    private Semester()
    {
        Id = Guid.NewGuid();
        MasaKuliah = "";
        TahunAjaran = "";
        CreatedAt = DateTime.UtcNow;
        MataKuliahId = "";
    }

    // Validate Invariant
    public static Result ValidateInvariant()
    {
        return Result.Success;
    }
}