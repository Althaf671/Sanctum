using MediatR;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.GetMataKuliahMetadataList;

internal sealed class GetMataKuliahMetadataListHandler
    : IRequestHandler<GetMataKuliahMetadataListQuery, Result<IReadOnlyList<MataKuliahMetadataListDto>>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetMataKuliahMetadataListHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result<IReadOnlyList<MataKuliahMetadataListDto>>> Handle(
        GetMataKuliahMetadataListQuery request, 
        CancellationToken cancellationToken)
    {
        var listMatkulMeta = await _dbContext.MataKuliah
            .AsNoTracking()
            .OrderBy(mk => mk.NamaMataKuliah)
            .ToListAsync(cancellationToken);
        
        return Result<IReadOnlyList<MataKuliahMetadataListDto>>
            .Success(listMatkulMeta.Select(MataKuliahMetadataListDto.FromDomain).ToList());
    }
}