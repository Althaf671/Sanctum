using src.Domain.Common;
using src.Domain.Enums;
using src.Domain.Errors.EntityErrors;
using src.Domain.ValueObjects;
using static src.Domain.Common.StringHelper.StringHelper;
using TugasEntity = src.Domain.Entities.MataKuliahAggregate.Tugas;

namespace src.Domain.Entities.MataKuliahAggregate;
public sealed class Materi : IEntity
{
    // Limit constants
    private const int _minPertemuanKeLength = 1;

    private const int _maxPertemuanKeLength = 14;

    // Properties
    public Guid Id { get; private set; }

    public string Judul { get; private set; } = string.Empty;

    public int PertemuanKe { get; private set; }

    public IsiMateri IsiMateri { get; private set; } = null!;

    public TipeMateri TipeMateri { get; private set; } 

    public bool IsSudahDibaca { get; private set; } = false;

    public DateTime? DibacaAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public DateTime CreatedAt { get; private set; } 

    // Backing field 
    public Guid MataKuliahId { get; private set; }
    
    private MataKuliah _mataKuliah = null!;

    public MataKuliah MataKuliah => _mataKuliah;

    // One-to-many backing field
    private List<Tugas> _tugas = new();

    public IReadOnlyCollection<Tugas> Tugas => _tugas.AsReadOnly();


    // EF core private constructor
    private Materi() { }

    // Private constructor
    private Materi(
        string judulMateri,
        IsiMateri isiMateri,
        TipeMateri tipeMateri,
        Guid mataKuliahId,
        int pertemuanKe)
    {
        Id = Guid.NewGuid();
        Judul = judulMateri;
        IsiMateri = isiMateri;
        TipeMateri = tipeMateri;
        MataKuliahId = mataKuliahId;
        PertemuanKe = pertemuanKe;
        IsSudahDibaca = false;
        CreatedAt = DateTime.UtcNow;
    }

    // Factory
    internal static Result<Materi> TambahMateri(
        string judulMateri,
        IsiMateri isiMateri,
        TipeMateri tipeMateri,
        Guid mataKuliahId,
        int pertemuanKe)
    {
        var validation = ValidateInvariant(judulMateri, pertemuanKe);
        if (validation.IsFailure)
            return Result<Materi>.Failure(validation.Error);

        return Result<Materi>.Success(
            new Materi(
                judulMateri,
                isiMateri,
                tipeMateri,
                mataKuliahId,
                pertemuanKe
            ));
    }


    //================= MATERI METHODS =================//
    internal Result GantiIsiMateri(IsiMateri isiMateri)
    {
        IsiMateri = isiMateri;
        UpdatedAt = DateTime.UtcNow;
        return Result.Success;
    }

    internal Result RevisiInfoMateri(
        string judul, 
        int pertemuanKe,
        TipeMateri tipeMateri)
    {
        var validation = ValidateInvariant(judul, pertemuanKe);
        if (validation.IsFailure)
            return Result.Failure(validation.Error);
            
        Judul = judul;
        PertemuanKe = pertemuanKe;
        TipeMateri = tipeMateri;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    internal Result TandaiMateriSudahDibaca()
    {
        IsSudahDibaca = true;
        DibacaAt = DateTime.UtcNow;
        return Result.Success;
    }
    //================= END OF METHODS =================//


    //================= TUGAS METHODS =================//
    internal Result TambahTugas(
        string judulTugas, 
        Url linkPengerjaanTugas, 
        Url linkPengumpulanTugas)
    {
        var newTugas = TugasEntity.TambahTugas(
            judulTugas, 
            linkPengerjaanTugas, 
            linkPengumpulanTugas,
            Id);
        if (newTugas.IsFailure)
            return Result.Failure(newTugas.Error);

        return Result.Success;
    }

    internal Result RevisiInfoTugas(
        Guid tugasId,
        string judulTugas,
        Url linkPengerjaanTugas,
        Url linkPengumpulanTugas)
    {
        var tugas = _tugas.FirstOrDefault(t => t.Id == tugasId);
        if (tugas is null)
            return Result.Failure(TugasErrors.TugasWithIdNotFound(tugasId));

        var newInfoTugas = tugas.RevisiInfoTugas(
            judulTugas, 
            linkPengerjaanTugas, 
            linkPengumpulanTugas);
        if (newInfoTugas.IsFailure)
            return Result.Failure(newInfoTugas.Error);

        return Result.Success;
    }

    internal Result HapusTugas(Guid tugasId)
    {
        var tugas = _tugas.FirstOrDefault(t => t.Id == tugasId);
        if (tugas is null)
            return Result.Failure(TugasErrors.TugasWithIdNotFound(tugasId));

        tugas.HapusTugas();

        return Result.Success;
    }

    internal Result TandaiTugasSudahDikumpul(Guid tugasId)
    {
        var tugas = _tugas.FirstOrDefault(t => t.Id == tugasId);
        if (tugas is null)
            return Result.Failure(TugasErrors.TugasWithIdNotFound(tugasId));

        tugas.TandaiTugasSudahDikumpul();

        return Result.Success;
    }

    internal Result TandaiTugasBelumDikumpul(Guid tugasId)
    {
        var tugas = _tugas.FirstOrDefault(t => t.Id == tugasId);
        if (tugas is null)
            return Result.Failure(TugasErrors.TugasWithIdNotFound(tugasId));

        tugas.TandaiTugasBelumDikumpul();

        return Result.Success;
    }
    //================= END OF METHODS =================//


    //================= MATERI BEHAVIOUR INVARIANT =================//
    private static Result ValidateInvariant(string judulMateri, int pertemuanKe)
    {
        if (IsBlank(judulMateri))
            return Result.Failure(MateriErrors.JudulMateriRequired());

        if (IsPertemuanOutOfRange(pertemuanKe))
            return Result.Failure(MateriErrors.PertemuanOutOfRange());

        return Result.Success; 
    }
    //================= END OF METHODS =================//

    // Helper
    private static bool IsPertemuanOutOfRange(int pertemuanKu) =>
        pertemuanKu < _minPertemuanKeLength || pertemuanKu > _maxPertemuanKeLength;

}