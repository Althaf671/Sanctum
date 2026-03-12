using MediatR;
using src.App.Common.Interfaces;
using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;
using src.SharedKernel.Domain.ValueObjects;
using MataKuliahEntity = src.Modules.AcademicDomain.Entities.MataKuliahAggregate.MataKuliah;

namespace src.Modules.Academic.App.MataKuliah.Commands.Materi.TambahMataKuliah;

internal sealed class TambahMataKuliahCommandHandler
    : IRequestHandler<TambahMataKuliahCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _dbContext;

    public TambahMataKuliahCommandHandler(IApplicationDbContext context)
    {
        _dbContext = context;    
    }
    
    public async Task<Result<Guid>> Handle(
        TambahMataKuliahCommand request, 
        CancellationToken cancellationToken)
    {
        var url = Url.Create(request.UrlValue);
        if (url.IsFailure)
            return Result<Guid>.Failure(url.Error);

        var waktuKuliah = WaktuKuliah.Create(
            request.TanggalKuliah, 
            request.JamMulaiKuliah, 
            request.JamBerakhirKuliah);
        if (waktuKuliah.IsFailure)
            return Result<Guid>.Failure(waktuKuliah.Error);

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
            return Result<Guid>.Failure(mataKuliah.Error);

        await _dbContext.MataKuliah.AddAsync(mataKuliah.Value!, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(mataKuliah.Value!.Id);
    }
}