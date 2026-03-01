using src.Domain.Common;
using src.Domain.ValueObjects;

namespace src.Domain.Entities;

public record RevisiInfoMataKuliahDto(
    string KodeMataKuliah, 
    string NamaMataKuliah, 
    int Sks, 
    string RuangKuliah, 
    string DosenPengampu, 
    Url LinkFolder);

public record TambahMataKuliahDto(
    RevisiInfoMataKuliahDto RevisiInfoMataKuliahDto,
    WaktuKuliah WaktuKuliah
);

public sealed class MataKuliah : IAggregateRoot, IEntity
{
    public Guid Id { get; private set; }

    public string KodeMataKuliah { get; private set; } 

    public string NamaMataKuliah { get; private set; } 

    public int Sks { get; private set; }

    public WaktuKuliah WaktuKuliah { get; private set; } 

    public string RuangKuliah { get; private set; } 

    public string DosenPengampu { get; private set; } 

    public Url LinkFolder { get; private set; } 

    public DateTime? UpdatedAt { get; private set; }

    public DateTime CreatedAt { get; private set; }

    // One-to-Many with backing field
    private List<Materi> _materi = new();

    public IReadOnlyCollection<Materi> Materi => _materi.AsReadOnly();

    // EF core private constructor
    private MataKuliah() { }

    // Factory
    public static Result<MataKuliah> TambahMataKuliah(TambahMataKuliahDto item)
    {
        // validate invariant

        return Result<MataKuliah>.Success(new MataKuliah(item));
    }

    // Private constructor
    private MataKuliah(TambahMataKuliahDto item)
    {
        Id = Guid.NewGuid();
        KodeMataKuliah = item.RevisiInfoMataKuliahDto.KodeMataKuliah;
        NamaMataKuliah = item.RevisiInfoMataKuliahDto.NamaMataKuliah;
        Sks = item.RevisiInfoMataKuliahDto.Sks;
        WaktuKuliah = item.WaktuKuliah;
        RuangKuliah = item.RevisiInfoMataKuliahDto.RuangKuliah;
        DosenPengampu = item.RevisiInfoMataKuliahDto.DosenPengampu;
        LinkFolder = item.RevisiInfoMataKuliahDto.LinkFolder;
        CreatedAt = DateTime.UtcNow;
    }

    // Validate invariant
    private static Result ValidateInvariant()
    {
        return Result.Success; 
    }

    // Ganti Waktu Kuliah
    public Result GantiWaktuKuliah(WaktuKuliah waktuKuliah)
    {
        WaktuKuliah = waktuKuliah;
        return Result.Success;
    }

    // Revisi Info Mata Kuliah
    public Result RevisiInfoMataKuliah(RevisiInfoMataKuliahDto item)
    {
        KodeMataKuliah = item.KodeMataKuliah;
        NamaMataKuliah = item.NamaMataKuliah;
        Sks = item.Sks;
        RuangKuliah = item.RuangKuliah;
        DosenPengampu = item.DosenPengampu;
        LinkFolder = item.LinkFolder;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }
}