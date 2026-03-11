using MediatR;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.Materi.GetMateriMetadataList;

internal sealed class GetMateriMetadataListQueryHandler
    : IRequestHandler<GetMateriMetadataListQuery, Result<IReadOnlyList<MateriMetadataDto>>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetMateriMetadataListQueryHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result<IReadOnlyList<MateriMetadataDto>>> Handle(
        GetMateriMetadataListQuery request, 
        CancellationToken cancellationToken)
    {
        var result = await _dbContext.Materi
            .AsNoTracking()
            .Where(m => m.MataKuliahId == request.MataKuliahId)
            .Select(m => new MateriMetadataDto(
                m.MataKuliahId,
                m.Id,
                m.Judul,
                m.TipeMateri,
                m.IsSudahDibaca))
            .ToListAsync(cancellationToken);

        return Result<IReadOnlyList<MateriMetadataDto>>.Success(result);
    }
}