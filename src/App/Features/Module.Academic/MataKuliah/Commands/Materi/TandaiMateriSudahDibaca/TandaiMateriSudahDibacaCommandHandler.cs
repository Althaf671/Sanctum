using MediatR;
using src.Domain.Common;
using src.Domain.Errors.EntityErrors;
using src.Domain.Interfaces;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.TandaiMateriSudahDibaca;

internal sealed class TandaiMateriSudahDibacaCommandHandler
    : IRequestHandler<TandaiMateriSudahDibacaCommand, Result>
{
    private readonly IMataKuliahRepository _mataKuliahContext;

    public TandaiMateriSudahDibacaCommandHandler(IMataKuliahRepository context)
    {
        _mataKuliahContext = context;
    }
    
    public async Task<Result> Handle(TandaiMateriSudahDibacaCommand request, CancellationToken cancellationToken)
    {
        var mataKuliah = await _mataKuliahContext.GetWithMateriByIdAsync(
            request.MataKuliahId,
            request.MateriId,
            cancellationToken
        );
        if (mataKuliah is null)
            return Result.Failure(MataKuliahErrors.MataKuliahWithIdNotFound(request.MataKuliahId));

        var result = mataKuliah.TandaiMateriSudahDibaca(request.MateriId);
        if (result.IsFailure)
            return Result.Failure(result.Error);

        await _mataKuliahContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}