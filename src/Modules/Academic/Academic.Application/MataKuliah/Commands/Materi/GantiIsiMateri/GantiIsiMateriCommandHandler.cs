using MediatR;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.Modules.AcademicDomain.Interfaces;
using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Commands.Materi.GantiIsiMateri;

internal sealed class GantiIsiMateriCommandHandler 
    : IRequestHandler<GantiIsiMateriCommand, Result>
{
    private readonly IMataKuliahRepository _mataKuliahContext;

    public GantiIsiMateriCommandHandler(IMataKuliahRepository context)
    {
        _mataKuliahContext = context;
    }

    public async Task<Result> Handle(GantiIsiMateriCommand request, CancellationToken cancellationToken)
    {
        var isiMateri = IsiMateri.Create(request.OriginalFileUrl, request.RingkasanMateri);
        if (isiMateri.IsFailure)
            return Result.Failure(isiMateri.Error);

        var mataKuliah = await _mataKuliahContext.GetWithMateriByIdAsync(
            request.MataKuliahId,
            request.MateriId,
            cancellationToken
        );
        if (mataKuliah is null)
            return Result.Failure(MataKuliahErrors.MataKuliahWithIdNotFound(request.MataKuliahId));

        var result = mataKuliah.GantiIsiMateri(request.MateriId, isiMateri.Value!);
        if (result.IsFailure)
            return Result.Failure(result.Error);

        await _mataKuliahContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}