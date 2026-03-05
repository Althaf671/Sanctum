using src.Domain.Common;
using src.Domain.Enums;
using src.Domain.Errors.EntityErrors;
using src.Domain.ValueObjects;

namespace src.Domain.Entities.MataKuliahAggregate;
public sealed partial class MataKuliah
{
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

        materi.RevisiInfoMateri(judul, pertemuanKe, tipeMateri);

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