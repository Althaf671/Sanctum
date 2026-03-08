using MediatR;
using src.App.Common.Interfaces;
using src.Domain.Common;
using src.Domain.ValueObjects;
using MataKuliahEntity = src.Domain.Entities.MataKuliahAggregate.MataKuliah;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.TambahMataKuliah;

internal sealed class TambahMataKuliahCommandHandler
    : IRequestHandler<TambahMataKuliahCommand, Result>
{
    private readonly IApplicationDbContext _dbContext;

    public TambahMataKuliahCommandHandler(IApplicationDbContext context)
    {
        _dbContext = context;    
    }
    
    public async Task<Result> Handle(TambahMataKuliahCommand request, CancellationToken cancellationToken)
    {
        var url = Url.Create(request.UrlValue);
        if (url.IsFailure)
            return Result.Failure(url.Error);

        var waktuKuliah = WaktuKuliah.Create(
            request.TanggalKuliah, 
            request.JamMulaiKuliah, 
            request.JamBerakhirKuliah);
        if (waktuKuliah.IsFailure)
            return Result.Failure(waktuKuliah.Error);

        var mataKuliah = MataKuliahEntity.TambahMataKuliah(
            request.KodeMataKuliah,
            request.NamaMataKuliah,
            request.Sks,
            request.RuangKuliah,
            request.DosenPengampu,
            url.Value!,
            waktuKuliah.Value!
        );
        if (mataKuliah.IsFailure)
            return Result.Failure(mataKuliah.Error);

        await _dbContext.MataKuliah.AddAsync(mataKuliah.Value!, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}