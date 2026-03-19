using src.Modules.AcademicDomain.Enums;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.SharedKernel.Domain.Common;
using PertemuanEntity = src.Modules.AcademicDomain.Entities.MataKuliahAggregate.Pertemuan;

namespace src.Modules.AcademicDomain.Entities.MataKuliahAggregate;
public sealed partial class MataKuliah
{
    public Result<PertemuanEntity> JadwalkanPertemuan(
        int pertemuanKe,
        DateOnly tanggal)
    {
        var isDuplikat = _pertemuan.Any(p => p.PertemuanKe == pertemuanKe && !p.IsDeleted);
        if (isDuplikat)
            return Result<PertemuanEntity>.Failure(PertemuanErrors.PertemuanSudahAda());

        var newPertemuan = PertemuanEntity.JadwalkanPertemuan(
            pertemuanKe,
            tanggal,
            Id
        );
        if (newPertemuan.IsFailure)
            return Result<PertemuanEntity>.Failure(newPertemuan.Error);
        
       _pertemuan.Add(newPertemuan.Value!);

       return Result<PertemuanEntity>.Success(newPertemuan.Value!);
    }

    public Result RevisiJadwalPertemuan(Guid pertemuanId, int pertemuanKe, DateOnly tanggal)
    {
        var pertemuan = _pertemuan.FirstOrDefault(p => p.Id == pertemuanId);
        if (pertemuan is null)
            return Result.Failure(PertemuanErrors.PertemuanWithIdNotFound(pertemuanId));

        var newJadwal = pertemuan.RevisiJadwalPertemuan(pertemuanKe, tanggal);
        if (newJadwal.IsFailure)
            return Result.Failure(newJadwal.Error);

        return Result.Success;
    }

    public Result UbahStatusKehadiran(Guid pertemuanId, StatusKehadiran status)
    {
        var pertemuan = _pertemuan.FirstOrDefault(p => p.Id == pertemuanId);
        if (pertemuan is null)
            return Result.Failure(PertemuanErrors.PertemuanWithIdNotFound(pertemuanId));

        pertemuan.UbahStatusKehadiran(status);

        return Result.Success;       
    }

    public Result HapusJadwalPertemuan(Guid pertemuanId)
    {
        var pertemuan = _pertemuan.FirstOrDefault(p => p.Id == pertemuanId);
        if (pertemuan is null)
            return Result.Failure(PertemuanErrors.PertemuanWithIdNotFound(pertemuanId));

        pertemuan.HapusJadwalPertemuan();

        return Result.Success;       
    }
}