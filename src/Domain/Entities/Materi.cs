using src.Domain.Common;
using src.Domain.Enums;
using src.Domain.ValueObjects;

namespace src.Domain.Entities;
public sealed class Materi : IEntity
{
    public Guid Id { get; private set; }

    public string Judul { get; private set; } = string.Empty;

    public int PertemuanKe { get; private set; }

    public IsiMateri IsiMateri { get; private set; }

    public TipeMateri TipeMateri { get; private set; }

    public bool IsSudahDibaca { get; private set; } = false;

    public DateTime? DibacaAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public DateTime CreatedAt { get; private set; } 

    public Guid MataKuliahId { get; private set; }

    // Backing field 
    private MataKuliah _mataKuliah;

    public MataKuliah MataKuliah => _mataKuliah;

    // One-to-many backing field
    private List<Tugas> _tugas = new();

    public IReadOnlyCollection<Tugas> Tugas => _tugas.AsReadOnly();

    // EF core private constructor
    private Materi() { }

    // Factory
    public static Result<Materi> TambahMateri()
    {
        return Result<Materi>.Success(new Materi());
    }

    // Private constructor
    private Materi(string something)
    {
        
    }

    // Validate invariant

    // GantiIsiMateri

    // RevisiInfoMateri

    // TandaiSudahDibaca

    // TandaiBelumDibaca
}