using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;
using src.SharedKernel.Domain.ValueObjects;
using static src.SharedKernel.Domain.Common.StringHelper.StringHelper;

namespace src.Modules.AcademicDomain.Entities.MataKuliahAggregate;
public sealed class Tugas : IEntity
{
    // Limit constants
    private const int MinJudulLength = 5;

    private const int MaxJudulLength = 30;
    

    // Properties
    public Guid Id { get; private set; }

    public string JudulTugas { get; private set; } =string.Empty;

    public Url LinkPengerjaanTugas { get; private set; } = null!;

    public Url LinkPengumpulanTugas { get; private set; } = null!;

    public Deadline? Deadline { get; private set; } 

    public bool IsTugasDikumpul { get; private set; }

    public bool IsDeleted { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Guid MateriId { get; private set; }

    // EF core private constructor
    private Tugas() { }


    // private constructor
    private Tugas(
        string judulTugas,
        Url linkPengerjaanTugas,
        Url linkPengumpulanTugas,
        Deadline deadline,
        Guid materiId)
    {
        Id = Guid.NewGuid();
        JudulTugas = judulTugas;
        LinkPengerjaanTugas = linkPengerjaanTugas;
        LinkPengumpulanTugas = linkPengumpulanTugas;

        IsTugasDikumpul = false;
        Deadline = deadline;
        IsDeleted = false;

        CreatedAt = DateTime.UtcNow;
        MateriId = materiId;
    }

    // Factory
    internal static Result<Tugas> TambahTugas(
        string judulTugas,
        Url linkPengerjaanTugas,
        Url linkPengumpulanTugas,
        Guid materiId,
        Deadline deadline)
    {
        // pre-validate
        if (IsBlank(judulTugas))
            return Result<Tugas>.Failure(TugasErrors.JudulTugasRequired());

        var cleanJudulTugas = TrimEdges(judulTugas);

        // validate invariant
        var validation = ValidateInvariant(cleanJudulTugas);
        if (validation.IsFailure)
            return Result<Tugas>.Failure(validation.Error);

        return Result<Tugas>.Success(new Tugas(
            cleanJudulTugas,
            linkPengerjaanTugas, 
            linkPengumpulanTugas,
            deadline,
            materiId
        ));
    }


    //================= TUGAS METHODS =================//
    internal Result RevisiInfoTugas(
        string judulTugas,
        Url linkPengerjaanTugas,
        Url linkPengumpulanTugas)
    {
        // pre-validate
        if (IsBlank(judulTugas))
            return Result.Failure(TugasErrors.JudulTugasRequired());

        var cleanJudulTugas = TrimEdges(judulTugas);

        // validate invariant
        var validation = ValidateInvariant(cleanJudulTugas);
        if (validation.IsFailure)
            return Result.Failure(validation.Error);

        JudulTugas = cleanJudulTugas;
        LinkPengerjaanTugas = linkPengerjaanTugas;
        LinkPengumpulanTugas = linkPengumpulanTugas;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    internal Result TugasJatuhTempo(Deadline deadline)
    {
        Deadline = deadline;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    internal Result HapusTugas()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    internal Result TandaiTugasSudahDikumpul()
    {
        IsTugasDikumpul = true;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    internal Result TandaiTugasBelumDikumpul()
    {
        IsTugasDikumpul = false;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }
    //================= END METHODS =================//


    //================= TUGAS BEHAVIOUR INVARIANT =================//
    private static Result ValidateInvariant(string cleanJudulTugas)
    {
        if (IsStringInputLengthOutOfRange(cleanJudulTugas, MinJudulLength, MaxJudulLength))
            return Result.Failure(TugasErrors.JudulTugasLengthOutOfRange());

        return Result.Success; 
    }
    //================= END METHODS =================//
}