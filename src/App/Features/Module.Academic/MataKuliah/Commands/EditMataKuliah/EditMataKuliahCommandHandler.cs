using MediatR;
using src.App.Common.Interfaces;
using src.Domain.Common;
using src.Domain.Errors.EntityErrors;
using src.Domain.ValueObjects;
using MataKuliahEntity = src.Domain.Entities.MataKuliahAggregate.MataKuliah;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.EditMataKuliah;

internal sealed class EditMataKuliahCommandHandler
    : IRequestHandler<EditMataKuliahCommand, Result>
{
    private readonly IApplicationDbContext _dbContext;

    public EditMataKuliahCommandHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result> Handle(EditMataKuliahCommand request, CancellationToken cancellationToken)
    {
        var mataKuliah = await _dbContext.MataKuliah.FindAsync([request.MataKuliahId], cancellationToken);
        if (mataKuliah is null)
            return Result.Failure(MataKuliahErrors.MataKuliahWithIdNotFound(request.MataKuliahId));

        var waktuKuliah = WaktuKuliah.Create(
            request.TanggalKuliah, 
            request.JamMulaiKuliah, 
            request.JamBerakhirKuliah);
        if (waktuKuliah.IsFailure)
            return Result.Failure(waktuKuliah.Error);

        var url = Url.Create(request.UrlValue);
        if (url.IsFailure)
            return Result.Failure(url.Error);

        var newWaktuKuliah = mataKuliah.GantiWaktuKuliah(waktuKuliah.Value!);
        if (newWaktuKuliah.IsFailure)
            return Result.Failure(newWaktuKuliah.Error);
            
        var result = mataKuliah.RevisiInfoMataKuliah(
            request.KodeMataKuliah,
            request.NamaMataKuliah,
            request.Sks,
            request.RuangKuliah,
            request.DosenPengampu,
            url.Value!
        );
        if (result.IsFailure)
            return Result.Failure(result.Error);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}
