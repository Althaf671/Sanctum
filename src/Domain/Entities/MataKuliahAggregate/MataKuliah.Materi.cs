using src.Domain.Common;
using src.Domain.Enums;
using src.Domain.Errors.EntityErrors;
using src.Domain.ValueObjects;
using MateriEntity = src.Domain.Entities.MataKuliahAggregate.Materi;

namespace src.Domain.Entities.MataKuliahAggregate;
public sealed partial class MataKuliah
{
    public Result TambahMateri(
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
            return Result.Failure(newMateri.Error);
        
        return Result.Success;
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