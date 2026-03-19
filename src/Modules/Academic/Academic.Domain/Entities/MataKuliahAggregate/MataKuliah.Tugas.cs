using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;
using src.SharedKernel.Domain.ValueObjects;

// konsep sialan ini disebut Law of Demeter - fahhh - i love it
namespace src.Modules.AcademicDomain.Entities.MataKuliahAggregate;
public sealed partial class MataKuliah
{
    public Result<Guid> TambahTugas(
        Guid materiId,
        string judulTugas,
        Url linkPengerjaanTugas,
        Url linkPengumpulanTugas,
        Deadline deadline)
    {
        var materi = _materi.FirstOrDefault(m => m.Id == materiId);
        if (materi is null)
            return Result<Guid>.Failure(MateriErrors.MateriWithIdNotFound(materiId));

        var newTugas = materi.TambahTugas(
            judulTugas,
            linkPengerjaanTugas,
            linkPengumpulanTugas,
            deadline);
        if (newTugas.IsFailure)
            return Result<Guid>.Failure(newTugas.Error);

        return Result<Guid>.Success(newTugas.Value);
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

    public Result TugasJatuhTempo(Guid materiId, Guid tugasId, Deadline deadline)
    {
        var materi = _materi.FirstOrDefault(m => m.Id == materiId);
        if (materi is null)
            return Result.Failure(MateriErrors.MateriWithIdNotFound(materiId));

        var jatuhTempo = materi.TugasJatuhTempo(tugasId, deadline);
        if (jatuhTempo.IsFailure)
            return Result.Failure(jatuhTempo.Error);   

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