using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.SharedKernel.Domain.Common;
using src.SharedKernel.Domain.ValueObjects;
using static src.SharedKernel.Domain.Common.StringHelper.StringHelper;

namespace src.Modules.AcademicDomain.Entities.MataKuliahAggregate;
public sealed class Tugas : IEntity
{
    // Limit constants
    private const int _minJudulLength = 5;

    private const int _maxJudulLength = 30;
    

    // Properties
    public Guid Id { get; private set; }

    public string JudulTugas { get; private set; } = null!;

    public Url LinkPengerjaanTugas { get; private set; } = null!;

    public Url LinkPengumpulanTugas { get; private set; } = null!;

    public bool IsTugasDikumpul { get; private set; }

    public bool IsDeleted { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Guid MateriId { get; private set; }


    // Backing field 
    private Materi _materi = null!;

    public Materi Materi => _materi;


    // EF core private constructor
    private Tugas() { }


    // private constructor
    private Tugas(
        string judulTugas,
        Url linkPengerjaanTugas,
        Url linkPengumpulanTugas,
        Guid materiId)
    {
        Id = Guid.NewGuid();
        LinkPengerjaanTugas = linkPengerjaanTugas;
        LinkPengumpulanTugas = linkPengumpulanTugas;
        JudulTugas = judulTugas;
        IsTugasDikumpul = false;
        IsDeleted = false;
        CreatedAt = DateTime.UtcNow;
        MateriId = materiId;
    }

    // Factory
    internal static Result<Tugas> TambahTugas(
        string judulTugas,
        Url linkPengerjaanTugas,
        Url linkPengumpulanTugas,
        Guid materiId)
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
            linkPengumpulanTugas,
            linkPengerjaanTugas, 
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

        JudulTugas = judulTugas;
        LinkPengerjaanTugas = linkPengerjaanTugas;
        LinkPengumpulanTugas = linkPengumpulanTugas;

        return Result.Success;
    }

    internal Result HapusTugas()
    {
        IsDeleted = true;
        return Result.Success;
    }

    internal Result TandaiTugasSudahDikumpul()
    {
        IsTugasDikumpul = true;
        return Result.Success;
    }

    internal Result TandaiTugasBelumDikumpul()
    {
        IsTugasDikumpul = false;
        return Result.Success;
    }
    //================= END METHODS =================//


    //================= TUGAS BEHAVIOUR INVARIANT =================//
    private static Result ValidateInvariant(string cleanJudulTugas)
    {
        if (IsStringInputLengthOutOfRange(cleanJudulTugas, _minJudulLength, _maxJudulLength))
            return Result.Failure(TugasErrors.JudulTugasLengthOutOfRange());

        return Result.Success; 
    }

    public Result Delete()
    {
        throw new NotImplementedException();
    }
    //================= END METHODS =================//
}