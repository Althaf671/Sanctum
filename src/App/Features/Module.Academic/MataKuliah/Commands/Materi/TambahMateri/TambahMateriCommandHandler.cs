using MediatR;
using src.App.Common.Interfaces;
using src.Domain.Common;
using src.Domain.Errors.EntityErrors;
using src.Domain.Interfaces;
using src.Domain.ValueObjects;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.TambahMateri;

internal sealed class TambahMateriCommandHandler
    : IRequestHandler<TambahMateriCommand, Result>
{
    private readonly IMataKuliahRepository _mataKuliahContext;

    public TambahMateriCommandHandler(IMataKuliahRepository context)
    {
        _mataKuliahContext = context;
    }

    public async Task<Result> Handle(TambahMateriCommand request, CancellationToken cancellationToken)
    {
        var isiMateri = IsiMateri.Create(request.OriginalFileUrl, request.RingkasanMateri);
        if (isiMateri.IsFailure)
            return Result.Failure(isiMateri.Error);

        var mataKuliah = await _mataKuliahContext.GetByIdAsync(request.MataKuliahId, cancellationToken);
        if (mataKuliah is null)
            return Result.Failure(MataKuliahErrors.MataKuliahWithIdNotFound(request.MataKuliahId));

        var result = mataKuliah.TambahMateri(
            request.JudulMateri,
            isiMateri.Value!,
            request.TipeMateri,
            request.PertemuanKe
        );
        if (result.IsFailure)
            return Result.Failure(result.Error);

        await _mataKuliahContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}