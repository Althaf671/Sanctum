using MediatR;
using src.App.Common.Interfaces;
using src.Domain.Common;
using src.Domain.Errors.EntityErrors;
using src.Domain.Interfaces;
using src.Domain.ValueObjects;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.TambahMateri;

internal sealed class TambahMateriCommandHandler
    : IRequestHandler<TambahMateriCommand, Result<Guid>>
{
    private readonly IMataKuliahRepository _mataKuliahContext;
    private readonly IApplicationDbContext _dbContext;

    public TambahMateriCommandHandler(
        IMataKuliahRepository context,
        IApplicationDbContext dbContext)
    {
        _mataKuliahContext = context;
        _dbContext = dbContext;
    }

    public async Task<Result<Guid>> Handle(TambahMateriCommand request, CancellationToken cancellationToken)
    {
        var isiMateri = IsiMateri.Create(request.OriginalFileUrl, request.RingkasanMateri);
        if (isiMateri.IsFailure)
            return Result<Guid>.Failure(isiMateri.Error);

        var mataKuliah = await _mataKuliahContext.GetByIdAsync(request.MataKuliahId, cancellationToken);
        if (mataKuliah is null)
            return Result<Guid>.Failure(MataKuliahErrors.MataKuliahWithIdNotFound(request.MataKuliahId));

        var result = mataKuliah.TambahMateri(
            request.JudulMateri,
            isiMateri.Value!,
            request.TipeMateri,
            request.PertemuanKe
        );
        if (result.IsFailure)
            return Result<Guid>.Failure(result.Error);

        await _dbContext.Materi.AddAsync(result.Value!);
        await _mataKuliahContext.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(result.Value!.Id);
    }
}