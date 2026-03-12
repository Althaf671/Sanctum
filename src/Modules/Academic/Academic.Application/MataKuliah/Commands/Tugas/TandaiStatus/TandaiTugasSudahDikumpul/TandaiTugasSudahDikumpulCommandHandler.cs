using MediatR;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.Modules.AcademicDomain.Interfaces;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Commands.Tugas.TandaiStatus.TandaiTugasSudahDikumpul;

internal sealed class TandaiTugasSudahDikumpulCommandHandler
    : IRequestHandler<TandaiTugasSudahDikumpulCommand, Result>
{
    private readonly IMataKuliahRepository _mataKuliahContext;

    public TandaiTugasSudahDikumpulCommandHandler(IMataKuliahRepository context)
    {
        _mataKuliahContext = context;
    }

    public async Task<Result> Handle(TandaiTugasSudahDikumpulCommand request, CancellationToken cancellationToken)
    {
        var mataKuliah = await _mataKuliahContext.GetMateriAndTugasByIdAsync(
            request.MataKuliahId,
            request.MateriId,
            request.TugasId,
            cancellationToken
        );
        if (mataKuliah is null)
            return Result.Failure(MataKuliahErrors.MataKuliahWithIdNotFound(request.MataKuliahId));

        var result = mataKuliah.TandaiTugasSudahDikumpul(request.MateriId, request.TugasId);
        if (result.IsFailure)
            return Result.Failure(result.Error);

        await _mataKuliahContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}