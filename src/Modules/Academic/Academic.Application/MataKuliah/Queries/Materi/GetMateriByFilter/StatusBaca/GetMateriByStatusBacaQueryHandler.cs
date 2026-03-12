using MediatR;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.Modules.Academic.App.MataKuliah.Queries.Materi.GetMateriMetadataList;
using src.SharedKernel.Domain.Common;


// # NEED REFACTOR
namespace src.Modules.Academic.App.MataKuliah.Queries.Materi.GetMateriByFilter.StatusBaca;

internal sealed class GetMateriByStatusBacaQueryHandler
    : IRequestHandler<GetMateriByStatusBacaQuery, Result<IReadOnlyList<MateriMetadataDto>>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetMateriByStatusBacaQueryHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result<IReadOnlyList<MateriMetadataDto>>> Handle(
        GetMateriByStatusBacaQuery request, 
        CancellationToken cancellationToken)
    {
        var result = await _dbContext.Materi
            .AsNoTracking()
            .Where(m => m.IsSudahDibaca == request.IsSudahDibaca)
            .Select(m => new MateriMetadataDto(
                m.MataKuliahId,
                m.Id,
                m.Judul,
                m.TipeMateri,
                m.IsSudahDibaca
            ))
            .OrderBy(m => m.Judul)
            .ToListAsync(cancellationToken);

        return Result<IReadOnlyList<MateriMetadataDto>>
            .Success(result);
    }
}
 