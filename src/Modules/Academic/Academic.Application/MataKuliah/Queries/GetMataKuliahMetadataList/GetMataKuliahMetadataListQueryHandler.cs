using MediatR;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Queries.GetMataKuliahMetadataList;

internal sealed class GetMataKuliahMetadataListHandler
    : IRequestHandler<GetMataKuliahMetadataListQuery, Result<IReadOnlyList<MataKuliahMetadataDto>>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetMataKuliahMetadataListHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result<IReadOnlyList<MataKuliahMetadataDto>>> Handle(
        GetMataKuliahMetadataListQuery request, 
        CancellationToken cancellationToken)
    {
        var result = await _dbContext.MataKuliah
            .AsNoTracking()
            .Select(mk => new MataKuliahMetadataDto(
                mk.Id,
                mk.KodeMataKuliah,
                mk.NamaMataKuliah,
                mk.WaktuKuliah,
                mk.RuangKuliah
            ))
            .OrderBy(mk => mk.NamaMataKuliah)
            .ToListAsync(cancellationToken);
        
        return Result<IReadOnlyList<MataKuliahMetadataDto>>.Success(result);
    }
}