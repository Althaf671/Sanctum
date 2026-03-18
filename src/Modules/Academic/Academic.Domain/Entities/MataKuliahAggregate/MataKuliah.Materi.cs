using src.Modules.AcademicDomain.Enums;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;
using MateriEntity = src.Modules.AcademicDomain.Entities.MataKuliahAggregate.Materi;

namespace src.Modules.AcademicDomain.Entities.MataKuliahAggregate;
public sealed partial class MataKuliah
{
    public Result<MateriEntity> TambahMateri(
        string judulMateri,
        IsiMateri isiMateri,
        TipeMateri tipeMateri,
        int pertemuanKe)
    {
        var newMateri = MateriEntity.TambahMateri(
            judulMateri,
            isiMateri,
            tipeMateri,
            Id,
            pertemuanKe
        );
        if (newMateri.IsFailure)
            return Result<MateriEntity>.Failure(newMateri.Error);

        _materi.Add(newMateri.Value!);
        
        return Result<MateriEntity>.Success(newMateri.Value!);
    }

    public Result GantiIsiMateri(Guid materiId, IsiMateri isiMateri)
    {
        var materi = _materi.FirstOrDefault(m => m.Id == materiId);
        if (materi is null)
            return Result.Failure(MateriErrors.MateriWithIdNotFound(materiId));

        materi.GantiIsiMateri(isiMateri);

        return Result.Success;
    }

    public Result RevisiInfoMateri(
        Guid materiId, 
        string judul, 
        int pertemuanKe, 
        TipeMateri tipeMateri)
    {
        var materi = _materi.FirstOrDefault(m => m.Id == materiId);
        if (materi is null)
            return Result.Failure(MateriErrors.MateriWithIdNotFound(materiId));

        var newInfoMateri = materi.RevisiInfoMateri(judul, pertemuanKe, tipeMateri);
        if (newInfoMateri.IsFailure)
            return Result.Failure(newInfoMateri.Error);

        return Result.Success;
    }

    public Result TandaiMateriSudahDibaca(Guid materiId)
    {
        var materi = _materi.FirstOrDefault(m => m.Id == materiId);
        if (materi is null)
            return Result.Failure(MateriErrors.MateriWithIdNotFound(materiId));

        materi.TandaiMateriSudahDibaca();

        return Result.Success;
    }
}