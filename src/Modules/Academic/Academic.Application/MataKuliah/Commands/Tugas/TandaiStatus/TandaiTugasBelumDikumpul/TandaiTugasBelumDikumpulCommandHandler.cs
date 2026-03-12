using MediatR;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.Modules.AcademicDomain.Interfaces;
using src.SharedKernel.Domain.Common;


namespace src.Modules.Academic.App.MataKuliah.Commands.Tugas.TandaiStatus.TandaiTugasBelumDikumpul;

internal sealed class TandaiTugasBelumDikumpulCommandHandler
    : IRequestHandler<TandaiTugasBelumDikumpulCommand, Result>
{
    private readonly IMataKuliahRepository _mataKuliahContext;

    public TandaiTugasBelumDikumpulCommandHandler(IMataKuliahRepository context)
    {
        _mataKuliahContext = context;
    }

    public async Task<Result> Handle(TandaiTugasBelumDikumpulCommand request, CancellationToken cancellationToken)
    {
        var mataKuliah = await _mataKuliahContext.GetMateriAndTugasByIdAsync(
            request.MataKuliahId,
            request.MateriId,
            request.TugasId,
            cancellationToken
        );
        if (mataKuliah is null)
            return Result.Failure(MataKuliahErrors.MataKuliahWithIdNotFound(request.MataKuliahId));

        var result = mataKuliah.TandaiTugasBelumDikumpul(request.MateriId, request.TugasId);
        if (result.IsFailure)
            return Result.Failure(result.Error);

        await _mataKuliahContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}