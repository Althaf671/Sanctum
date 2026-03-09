using MediatR;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.Tugas.GetTugasMetadataList;

internal sealed class GetTugasMetadataListQueryHandler
    : IRequestHandler<GetTugasMetadataListQuery, Result<IReadOnlyList<TugasMetadataDto>>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetTugasMetadataListQueryHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result<IReadOnlyList<TugasMetadataDto>>> Handle(
        GetTugasMetadataListQuery request, 
        CancellationToken cancellationToken)
    {
        var tugasList = await _dbContext.Tugas
            .AsNoTracking()
            .Where(t => t.MateriId == request.MateriId)
            .Select(t => new TugasMetadataDto(
                t.Id,
                t.JudulTugas,
                t.IsTugasDikumpul
            ))
            .OrderBy(t => t.JudulTugas)
            .ToListAsync(cancellationToken);
            
        return Result<IReadOnlyList<TugasMetadataDto>>.Success(tugasList);
    }
}