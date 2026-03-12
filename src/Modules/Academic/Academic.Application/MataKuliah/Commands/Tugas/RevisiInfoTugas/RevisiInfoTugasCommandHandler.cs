using MediatR;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.Modules.AcademicDomain.Interfaces;
using src.SharedKernel.Domain.Common;
using src.SharedKernel.Domain.ValueObjects;

namespace src.Modules.Academic.App.MataKuliah.Commands.Tugas.RevisiInfoTugas;

internal sealed class RevisiInfoTugasCommandHandler
    : IRequestHandler<RevisiInfoTugasCommand, Result>
{
    private readonly IMataKuliahRepository _mataKuliahContext;

    public RevisiInfoTugasCommandHandler(IMataKuliahRepository context)
    {
        _mataKuliahContext = context;
    }

    public async Task<Result> Handle(RevisiInfoTugasCommand request, CancellationToken cancellationToken)
    {
        var linkPengerjaanTugas = Url.Create(request.UrlLinkPengerjaanTugas);
        if (linkPengerjaanTugas.IsFailure)
            return Result.Failure(linkPengerjaanTugas.Error);

        var linkPengumpulanTugas = Url.Create(request.UrlLinkPengumpulanTugas);
        if (linkPengumpulanTugas.IsFailure)
            return Result.Failure(linkPengumpulanTugas.Error);

        var mataKuliah = await _mataKuliahContext.GetMateriAndTugasByIdAsync(
            request.MataKuliahId,
            request.MateriId,
            request.TugasId,
            cancellationToken
        );
        if (mataKuliah is null)
            return Result.Failure(MataKuliahErrors.MataKuliahWithIdNotFound(request.MataKuliahId));

        var result = mataKuliah.RevisiInfoTugas(
            request.MateriId,
            request.TugasId,
            request.JudulTugas,
            linkPengerjaanTugas.Value!,
            linkPengumpulanTugas.Value!
        );
        if (result.IsFailure)
            return Result.Failure(result.Error);

        await _mataKuliahContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}