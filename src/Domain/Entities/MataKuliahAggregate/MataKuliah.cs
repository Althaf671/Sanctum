using src.Domain.Common;
using src.Domain.Errors.EntityErrors;
using src.Domain.ValueObjects;
using static src.Domain.Common.StringHelper.StringHelper;

namespace src.Domain.Entities.MataKuliahAggregate;
public sealed class MataKuliah : IAggregateRoot, IEntity
{
    // Limit constants
    private const int MinStringInputLength = 10;

    private const int MaxStringInputLength = 40;

    private const int MinSksInputLength = 1;

    private const int MaxSksInputLength = 3;


    // Properties
    public Guid Id { get; private set; }

    public string KodeMataKuliah { get; private set; } = null!;

    public string NamaMataKuliah { get; private set; } = null!;

    public int Sks { get; private set; }

    public WaktuKuliah WaktuKuliah { get; private set; } = null!;

    public string RuangKuliah { get; private set; } = null!;

    public string DosenPengampu { get; private set; } = null!;

    public Url LinkFolder { get; private set; } = null!;

    public DateTime? UpdatedAt { get; private set; }

    public DateTime CreatedAt { get; private set; }

    // One-to-Many with backing field
    private List<Materi> _materi = new();

    public IReadOnlyCollection<Materi> Materi => _materi.AsReadOnly();


    // EF core private constructor
    private MataKuliah() { }


    // Private constructor
    private MataKuliah(
        string kodeMataKuliah,
        string namaMataKuliah,
        int sks,
        string ruangKuliah,
        string dosenPengampu,
        Url link,
        WaktuKuliah waktuKuliah)
    {
        Id = Guid.NewGuid();
        KodeMataKuliah = kodeMataKuliah;
        NamaMataKuliah = namaMataKuliah;
        Sks = sks;
        WaktuKuliah = waktuKuliah;
        RuangKuliah = ruangKuliah;
        DosenPengampu = dosenPengampu;
        LinkFolder = link;
        CreatedAt = DateTime.UtcNow;
    }


    // Factory
    public static Result<MataKuliah> TambahMataKuliah(
        string kodeMataKuliah,
        string namaMataKuliah,
        int sks,
        string ruangKuliah,
        string dosenPengampu,
        Url link,
        WaktuKuliah waktuKuliah)
    {
        // pre-validate
        var preValidation = PreValidation(
            kodeMataKuliah,
            namaMataKuliah,
            sks,
            ruangKuliah,
            dosenPengampu);
        if (preValidation.IsFailure)
            return Result<MataKuliah>.Failure(preValidation.Error);

        // validate invariant
        var validation = ValidateInvariant(
            kodeMataKuliah,
            namaMataKuliah,
            sks,
            ruangKuliah,
            dosenPengampu);
        if (validation.IsFailure)
            return Result<MataKuliah>.Failure(validation.Error);

        return Result<MataKuliah>.Success(
            new MataKuliah(
                kodeMataKuliah,
                namaMataKuliah,
                sks,
                ruangKuliah,
                dosenPengampu,
                link,
                waktuKuliah
            ));
    }
    

    //================= MATA KULIAH AGGREGATE METHODS =================//
    // Ganti Waktu Kuliah
    public Result GantiWaktuKuliah(WaktuKuliah waktuKuliah)
    {
        WaktuKuliah = waktuKuliah;
        UpdatedAt = DateTime.UtcNow;
        return Result.Success;
    }

    // Revisi Info Mata Kuliah
    public Result RevisiInfoMataKuliah(
        string kodeMataKuliah,
        string namaMataKuliah,
        int sks,
        string ruangKuliah,
        string dosenPengampu,
        Url link)
    {
        // Pre-validate
        var preValidation = PreValidation(
            kodeMataKuliah, 
            namaMataKuliah, 
            sks, 
            ruangKuliah, 
            dosenPengampu);
        if (preValidation.IsFailure)
            return Result.Failure(preValidation.Error);
            
        // Validate invariant
        var validation = ValidateInvariant(
            kodeMataKuliah, 
            namaMataKuliah, 
            sks, 
            ruangKuliah, 
            dosenPengampu);
        if (validation.IsFailure)
            return Result.Failure(validation.Error);

        KodeMataKuliah = kodeMataKuliah;
        NamaMataKuliah = namaMataKuliah;
        Sks = sks;
        RuangKuliah = ruangKuliah;
        DosenPengampu = dosenPengampu;
        LinkFolder = link;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }
    //================= END OF METHODS =================//



    //================= MATERI CHILD METHODS =================//
    // Ganti isi materi - ex
    public Result<Materi> GantiIsiMateri()
    {
        var materi = _materi.FirstOrDefault();

        materi.GantiIsiMateri();

        return Result<Materi>.Success();
    }

    // Revisi info materi - ex
    public Result<Materi> RevisiInfoMateri()
    {
        var newMateriInfo = _materi.FirstOrDefault();

        newMateriInfo.RevisiInfoMateri();

        return Result<Materi>.Success();
    }

    // Tandai materi sudah dibaca - ex
    public Result<Materi> TandaiMateriSudahDibaca()
    {
        var statusBaca = _materi.FirstOrDefault();

        statusBaca.TandaiMateriSudahDibaca();

        return Result<Materi>.Success();
    }

    // Tandai materi belum dibaca - ex
    public Result<Materi> TandaiMateriBelumDibaca()
    {
        var statusBaca = _materi.FirstOrDefault();

        statusBaca.TandaiMateriBelumDibaca();

        return Result<Materi>.Success(); 
    }
    //================= END OF METHODS =================//



    //================= TUGAS GRANDCHIDLRED METHODS =================//
    // Revisi info tugas
    public Result<Tugas> RevisiInfoTugas()
    {
        var materi = _materi.FirstOrDefault();

        tugasInfo.RevisiInfoTugas();

        return Result<Tugas>.Success();
    }

    // Hapus tugas
    public Result<Tugas> HapusTugas()
    {
        var tugas = _materi.FirstOrDefault();

        tugas.HapusTugas();

        return Result<Tugas>.Success();
    }

    // Tandai tugas sudah dikumpul
    public Result<Tugas> TandaiTugasSudahDikumpul()
    {
        var statusTugas = _materi.FirstOrDefault();

        statusTugas.TandaiTugasSudahDikumpul();

        return Result<Tugas>.Success();
    }

    // Tandai tugas belum dikumpul
    public Result<Tugas> TandaiTugasSudahDikumpul()
    {
        var statusTugas = _materi.FirstOrDefault();

        statusTugas.TandaiTugasBelumDikumpul();

        return Result<Tugas>.Success();
    }
    //================= END OF METHODS =================//



    //================= MATAKULIAH BEHAVIOUR INVARIANT =================//
    private static Result PreValidation(
        string kodeMataKuliah,
        string namaMataKuliah,
        int sks,
        string ruangKuliah,
        string dosenPengampu)
    {
        if (IsBlank(kodeMataKuliah))
            return Result.Failure(MataKuliahErrors.ValueRequired("Kode mata kuliah"));

        if (IsBlank(namaMataKuliah))
            return Result.Failure(MataKuliahErrors.ValueRequired("Nama mata kuliah"));

        if (IsBlank(ruangKuliah))
            return Result.Failure(MataKuliahErrors.ValueRequired("Ruang kuliah"));

        if (IsBlank(dosenPengampu))
            return Result.Failure(MataKuliahErrors.ValueRequired("Dosen pengampu"));

        return Result.Success;
    }

    private static Result ValidateInvariant(
        string kodeMataKuliah,
        string namaMataKuliah,
        int sks,
        string ruangKuliah,
        string dosenPengampu)
    {
        // min and max kode mata kuliah is 10 or 40 characters
        if (IsStringInputLengthOutOfRange(kodeMataKuliah, MinStringInputLength, MaxStringInputLength))
            return Result.Failure(MataKuliahErrors.InvalidInputLength("Kode mata kuliah"));

        // min and max nama mata kuliah is 10 or 40 characters
        if (IsStringInputLengthOutOfRange(namaMataKuliah, MinStringInputLength, MaxStringInputLength))
            return Result.Failure(MataKuliahErrors.InvalidInputLength("Nama mata kuliah"));

        // dosen pengampu min and maks is 10 or 40 characters
        if (IsStringInputLengthOutOfRange(dosenPengampu, MinStringInputLength, MaxStringInputLength))
            return Result.Failure(MataKuliahErrors.InvalidInputLength("Dosen Pengampu"));

        // min and max sks is 1 or 3
        if (IsSksInputLengthOutOfRange(sks))
            return Result.Failure(MataKuliahErrors.InvalidSksLength());

        return Result.Success; 
    }
    //================= END OF METHODS =================//

    // Helper 
    private static bool IsSksInputLengthOutOfRange(int input) =>
        input < MinSksInputLength || input > MaxSksInputLength;
}