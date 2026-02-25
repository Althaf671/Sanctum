using src.Domain.Common;
using src.Domain.ValueObjects;

namespace src.Domain.Entities;

public sealed class MataKuliah : IAggregateRoot, IEntity
{
    public Guid Id { get; private set; }

    public string KodeMataKuliah { get; private set; } = string.Empty;

    public string NamaMataKuliah { get; private set; } = string.Empty;

    public int Sks { get; private set; }

    public WaktuKuliah WaktuKuliah { get; private set; }

    public string RuangKuliah { get; private set; } = string.Empty;

    public string DosenPengampu { get; private set; } = string.Empty;

    public Url LinkFolder { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public DateTime CreatedAt { get; private set; }

    // One-to-Many with backing field
    private List<Materi> _materi = new();

    public IReadOnlyCollection<Materi> Materi => _materi.AsReadOnly();

    // EF core private constructor
    private MataKuliah() { }

    // Factory
    public static Result<MataKuliah> TambahMataKuliah()
    {
        return Result<MataKuliah>.Success(new MataKuliah());
    }

    // Private constructor
    private MataKuliah(string something)
    {
        
    }

    // Validate invariant

    // GantiWaktuKuliah

    // RevisiInfoMataKuliah
}