using src.Domain.Common;
using src.Domain.ValueObjects;

namespace src.Domain.Entities;
public sealed class Tugas : IEntity
{
    public Guid Id { get; private set; }

    public string JudulTugas { get; private set; }

    public Url LinkPengerjaanTugas { get; private set; }

    public Url LinkPengumpulanTugas { get; private set; }

    public bool IsTugasDikumpul { get; private set; }

    public bool IsDeleted { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Guid MateriId { get; private set; }

    // Backing field 
    private Materi _materi;

    public Materi Materi => _materi;

    // EF core private constructor
    private Tugas() { }

    // Factory
    public static Result<Tugas> TambahTugas()
    {
        // pre-validate

        // validate invariant

        return Result<Tugas>.Success(new Tugas());
    }

    // private constructor
    private Tugas(string something)
    {
        
    }

    // Validate invariant
    private static Result ValidateInvariant()
    {
        return Result.Success; 
    }

    // // RevisiInfoTugas
    // public Result<Tugas> RevisiInfoTugas()
    // {
    //     return Result<Tugas>.Success();
    // }

    // // HapusTugas
    // public Result<Tugas> HapusTugas()
    // {
    //     return Result<Tugas>.Success();
    // }

    // // TandaiSudahDikumpul
    // public Result<Tugas> TandaiSudahDikumpul()
    // {
    //     return Result<Tugas>.Success();
    // }

    // // TandaiBelumDikumpul
    // public Result<Tugas> TandaiBelumDikumpul()
    // {
    //     return Result<Tugas>.Success();
    //}
}