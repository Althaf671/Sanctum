using src.Domain.Common;
using src.Domain.Enums;
using src.Domain.ValueObjects;

namespace src.Domain.Entities.MataKuliahAggregate;
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

    // Backing field 
    public Guid MataKuliahId { get; private set; }
    
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
    private static Result ValidateInvariant()
    {
        return Result.Success; 
    }

    // // Ganti Isi Materi
    internal Result<Materi> GantiIsiMateri()
    {
        return Result<Materi>.Success();
    }

    // Revisi Info Materi
    internal Result<Materi> RevisiInfoMateri()
    {
        return Result<Materi>.Success();
    }

    // Tandai materi Sudah Dibaca
    internal Result<Materi> TandaiMateriSudahDibaca()
    {
        return Result<Materi>.Success();
    }

    // Tandai materi Belum Dibaca    
    internal Result<Materi> TandaiMateriBelumDibaca()
    {
        return Result<Materi>.Success();
    }

    // Revisi info tugas
    internal Result<Tugas> RevisiInfoTugas()
    {
        var tugas = _tugas.FirstOrDefault();

        tugas.RevisiInfoTugas();

        return Result<Tugas>.Success();
    }

    // Hapus tugas
    internal Result<Tugas> HapusTugas()
    {
        var tugas = _tugas.FirstOrDefault();

        tugas.HapusTugas();

        return Result<Tugas>.Success();
    }

    // Tandai tugas Sudah Dikumpul
    internal Result<Tugas> TandaiTugasSudahDikumpul()
    {
        var statusTugas = _tugas.FirstOrDefault();

        statusTugas.TandaiTugasSudahDikumpul();

        return Result<Tugas>.Success();
    }

    // Tandai tugas belum dikumpul
    internal Result<Tugas> TandaiTugasBelumDikumpul()
    {
        var statusBaca = _tugas.FirstOrDefault();

        statusBaca.TandaiTugasBelumDikumpul();

        return Result<Tugas>.Success();
    }
}