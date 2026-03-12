using MediatR;
using src.App.Common.Interfaces;
using src.SharedKernel.Domain.Common;
using JurusanEntity = src.Modules.AcademicDomain.Entities.Jurusan;

namespace src.Modules.Academic.App.Jurusan.Commands.DaftarkanJurusan;

internal sealed class DaftarkanJurusanCommandHandler :
    IRequestHandler<DaftarkanJurusanCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _dbContext;

    public DaftarkanJurusanCommandHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result<Guid>> Handle(DaftarkanJurusanCommand request, CancellationToken cancellationToken)
    {
        var jurusan = JurusanEntity.DaftarkanJurusan(
            request.KodeJurusan,
            request.NamaJurusan,
            request.NamaFakultas,
            request.Jenjang,
            request.Akreditasi
        );
        if (jurusan.IsFailure)
            return Result<Guid>.Failure(jurusan.Error);

        await _dbContext.Jurusan.AddAsync(jurusan.Value!, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(jurusan.Value!.Id);
    }
}