using src.Domain.Common;
using src.Domain.Errors.EntityErrors;
using src.Domain.ValueObjects;


// konsep sialan ini disebut Law of Demeter - fahhh - i love it
namespace src.Domain.Entities.MataKuliahAggregate;
public sealed partial class MataKuliah
{
    public Result TambahTugas(
        Guid materiId,
        string judulTugas,
        Url linkPengerjaanTugas,
        Url linkPengumpulanTugas)
    {
        var materi = _materi.FirstOrDefault(m => m.Id == materiId);
        if (materi is null)
            return Result.Failure(MateriErrors.MateriWithIdNotFound(materiId));

        var newTugas = materi.TambahTugas(
            judulTugas,
            linkPengerjaanTugas,
            linkPengumpulanTugas);
        if (newTugas.IsFailure)
            return Result.Failure(newTugas.Error);

        return Result.Success;
    }

    public Result RevisiInfoTugas(
        Guid materiId,
        Guid tugasId,
        string judulTugas,
        Url linkPengerjaanTugas,
        Url linkPengumpulanTugas)
    {
        var materi = _materi.FirstOrDefault(m => m.Id == materiId);
        if (materi is null)
            return Result.Failure(MateriErrors.MateriWithIdNotFound(materiId));

        var newInfoTugas = materi.RevisiInfoTugas(
            tugasId,
            judulTugas,
            linkPengerjaanTugas,
            linkPengumpulanTugas
        );
        if (newInfoTugas.IsFailure)
            return Result.Failure(newInfoTugas.Error);

        return Result.Success;
    }

    public Result HapusTugas(Guid materiId, Guid tugasId)
    {
        var materi = _materi.FirstOrDefault(m => m.Id == materiId);
        if (materi is null)
            return Result.Failure(MateriErrors.MateriWithIdNotFound(materiId));

        var deleteTugas = materi.HapusTugas(tugasId);
        if (deleteTugas.IsFailure)
            return Result.Failure(deleteTugas.Error);       

        return Result.Success;
    }

    public Result TandaiTugasSudahDikumpul(Guid materiId, Guid tugasId)
    {
        var materi = _materi.FirstOrDefault(m => m.Id == materiId);
        if (materi is null)
            return Result.Failure(MateriErrors.MateriWithIdNotFound(materiId));

        var statusTugas = materi.TandaiTugasSudahDikumpul(tugasId);
        if (statusTugas.IsFailure)
            return Result.Failure(statusTugas.Error);

        return Result.Success;
    }

    public Result TandaiTugasBelumDikumpul(Guid materiId, Guid tugasId)
    {
        var materi = _materi.FirstOrDefault(m => m.Id == materiId);
        if (materi is null)
            return Result.Failure(MateriErrors.MateriWithIdNotFound(materiId));

        var statusTugas = materi.TandaiTugasBelumDikumpul(tugasId);
        if (statusTugas.IsFailure)
            return Result.Failure(statusTugas.Error);

        return Result.Success;
    }
}