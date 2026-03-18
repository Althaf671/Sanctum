using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;
using src.SharedKernel.Domain.Entities;
using src.SharedKernel.Domain.ValueObjects;
using static src.SharedKernel.Domain.Common.StringHelper.StringHelper;

namespace src.Modules.AcademicDomain.Entities.MataKuliahAggregate;
public sealed partial class MataKuliah : IAggregateRoot, IEntity
{
    // Limit constants
    private const int MinStringInputLength = 10;

    private const int MaxStringInputLength = 40;

    private const int MinSksInput = 1;

    private const int MaxSksInput = 3;


    // Properties
    public Guid Id { get; private set; }

    public string KodeMataKuliah { get; private set; } = string.Empty;

    public string NamaMataKuliah { get; private set; } = string.Empty;

    public int Sks { get; private set; }

    public WaktuKuliah WaktuKuliah { get; private set; } = null!;

    public string RuangKuliah { get; private set; } = string.Empty;

    public string DosenPengampu { get; private set; } = string.Empty;

    public Url LinkFolder { get; private set; } = null!;

    public bool IsDeleted { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public DateTime CreatedAt { get; private set; }
    

    // One-to-Many with backing field
    private List<Materi> _materi = new();

    public IReadOnlyCollection<Materi> Materi => _materi.AsReadOnly();

    private List<Pertemuan> _pertemuan = new();

    public IReadOnlyCollection<Pertemuan> Pertemuan => _pertemuan.AsReadOnly();


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

        IsDeleted = false;
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


    //================= MATA KULIAH METHODS =================//
    public Result GantiWaktuKuliah(WaktuKuliah waktuKuliah)
    {
        WaktuKuliah = waktuKuliah;
        UpdatedAt = DateTime.UtcNow;
        return Result.Success;
    }

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

    public Result HapusMataKuliah()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
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
            return Result.Failure(MataKuliahErrors.ValueRequired("Kode Mata Kuliah"));

        if (IsBlank(namaMataKuliah))
            return Result.Failure(MataKuliahErrors.ValueRequired("Nama Mata Kuliah"));

        if (IsBlank(ruangKuliah))
            return Result.Failure(MataKuliahErrors.ValueRequired("Ruang Kuliah"));

        if (IsBlank(dosenPengampu))
            return Result.Failure(MataKuliahErrors.ValueRequired("Dosen Pengampu"));

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
        input < MinSksInput || input > MaxSksInput;

}