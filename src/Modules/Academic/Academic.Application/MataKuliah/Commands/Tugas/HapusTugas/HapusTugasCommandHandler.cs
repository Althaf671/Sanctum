using MediatR;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.Modules.AcademicDomain.Interfaces;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Commands.Tugas.HapusTugas;

internal sealed class HapusTugasCommandHandler
    : IRequestHandler<HapusTugasCommand, Result>
{
    private readonly IMataKuliahRepository _mataKuliahContext;

    public HapusTugasCommandHandler(IMataKuliahRepository context)
    {
        _mataKuliahContext = context;    
    }

    public async Task<Result> Handle(HapusTugasCommand request, CancellationToken cancellationToken)
    {
        var mataKuliah = await _mataKuliahContext.GetMateriAndTugasByIdAsync(
            request.MataKuliahId,
            request.MateriId,
            request.TugasId,
            cancellationToken
        );
        if (mataKuliah is null)
            return Result.Failure(MataKuliahErrors.MataKuliahWithIdNotFound(request.MataKuliahId));

        var result = mataKuliah.HapusTugas(request.MateriId, request.TugasId);
        if (result.IsFailure)
            return Result.Failure(result.Error);

        await _mataKuliahContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}