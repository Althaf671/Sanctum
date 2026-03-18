using src.Modules.AcademicDomain.Enums;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.SharedKernel.Domain.Common;

namespace src.Modules.AcademicDomain.Entities.MataKuliahAggregate;

public sealed class Pertemuan : IEntity
{
    private const int MinPertemuanKe = 1;

    private const int MaxPertemuanKe = 16;

    public Guid Id { get; private set; }

    public int PertemuanKe { get; private set; }

    public DateOnly Tanggal { get; private set; }

    public StatusKehadiran StatusKehadiran { get; private set; }

    public bool IsDeleted { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Guid MataKuliahId { get; private set; }

    private Pertemuan() { }

    private Pertemuan(
        int pertemuanKe,
        DateOnly tanggal,
        Guid mataKuliahId)
    {
        Id = Guid.NewGuid();
        PertemuanKe = pertemuanKe;
        Tanggal = tanggal;
        StatusKehadiran = StatusKehadiran.BelumDihadiri;
        IsDeleted = false;
        MataKuliahId = mataKuliahId;
        CreatedAt = DateTime.UtcNow;
    }

    internal static Result<Pertemuan> DaftarkanPertemuan(
        int pertemuanKe,
        DateOnly tanggal,
        Guid mataKuliahId)
    {
        var validation = ValidateInvariant(pertemuanKe, tanggal);
        if (validation.IsFailure)
            return Result<Pertemuan>.Failure(validation.Error);

        return Result<Pertemuan>.Success(new Pertemuan(
            pertemuanKe, 
            tanggal,
            mataKuliahId
        ));
    }

    internal Result RevisiJadwalPertemuan(int pertemuanKe, DateOnly tanggal)
    {
        var validation = ValidateInvariant(pertemuanKe, tanggal);
        if (validation.IsFailure)
            return Result.Failure(validation.Error);

        PertemuanKe = pertemuanKe;
        Tanggal = tanggal;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    internal Result UbahStatusKehadiran(StatusKehadiran status)
    {
        StatusKehadiran = status;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    internal Result HapusJadwalPertemuan()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;

        return Result.Success;
    }

    private static Result ValidateInvariant(int pertemuanKe, DateOnly tanggal)
    {
        if (pertemuanKe < MinPertemuanKe || pertemuanKe > MaxPertemuanKe)
            return Result.Failure(PertemuanErrors.InvalidPertemuanKe());
        
        if (tanggal == DateOnly.MinValue)
            return Result.Failure(PertemuanErrors.TanggalPertemuanInvalid());
            
        return Result.Success;
    }
}