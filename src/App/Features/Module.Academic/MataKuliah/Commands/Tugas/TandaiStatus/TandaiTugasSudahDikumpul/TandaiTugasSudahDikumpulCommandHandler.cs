using MediatR;
using src.Domain.Common;
using src.Domain.Errors.EntityErrors;
using src.Domain.Interfaces;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Tugas.TandaiStatus.TandaiTugasSudahDikumpul;

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