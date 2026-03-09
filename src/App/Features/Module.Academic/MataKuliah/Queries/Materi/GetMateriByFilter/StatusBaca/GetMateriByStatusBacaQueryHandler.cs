using MediatR;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.App.Features.ModuleKuliah.MataKuliah.Queries.Materi.GetMateriMetadataList;
using src.Domain.Common;

// # NEED REFACTOR
namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.Materi.GetMateriByFilter.StatusBaca;

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
            .OrderBy(m => m.Judul)
            .ToListAsync(cancellationToken);

        return Result<IReadOnlyList<MateriMetadataDto>>
            .Success(result.Select(MateriMetadataDto.FromDomain).ToList());
    }
}