using FluentValidation;
using MediatR;
using src.Domain.Common;
using src.Domain.Errors.EntityErrors;
using src.Domain.Interfaces;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.RevisiInfoMateri;

internal sealed class RevisiInfoMateriCommandHandler 
    : IRequestHandler<RevisiInfoMateriCommand, Result>
{
    private readonly IMataKuliahRepository _mataKuliahContext;

    public RevisiInfoMateriCommandHandler(IMataKuliahRepository context)
    {
        _mataKuliahContext = context;
    }

    public async Task<Result> Handle(RevisiInfoMateriCommand request, CancellationToken cancellationToken)
    {
        var mataKuliah = await _mataKuliahContext.GetWithMateriByIdAsync(
            request.MataKuliahId, 
            request.MateriId, 
            cancellationToken);
        if (mataKuliah is null) 
            return Result.Failure(MataKuliahErrors.MataKuliahWithIdNotFound(request.MataKuliahId));

        var result = mataKuliah.RevisiInfoMateri(
            request.MateriId,
            request.JudulMateri,
            request.PertemuanKe,
            request.TipeMateri
        );
        if (result.IsFailure)
            return Result.Failure(result.Error);

        await _mataKuliahContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}