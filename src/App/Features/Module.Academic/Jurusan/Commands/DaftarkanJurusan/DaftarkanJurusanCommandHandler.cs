using MediatR;
using src.App.Common.Interfaces;
using src.Domain.Common;
using JurusanEntity = src.Domain.Entities.Jurusan;

namespace src.App.Features.ModuleKuliah.Jurusan.Commands.DaftarkanJurusan;

internal sealed class DaftarkanJurusanCommandHandler :
    IRequestHandler<DaftarkanJurusanCommand, Result>
{
    private readonly IApplicationDbContext _dbContext;

    public DaftarkanJurusanCommandHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result> Handle(DaftarkanJurusanCommand request, CancellationToken cancellationToken)
    {
        var jurusan = JurusanEntity.DaftarkanJurusan(
            request.KodeJurusan,
            request.NamaJurusan,
            request.NamaFakultas,
            request.Jenjang,
            request.Akreditasi
        );
        if (jurusan.IsFailure)
            return Result.Failure(jurusan.Error);

        await _dbContext.Jurusan.AddAsync(jurusan.Value!, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}