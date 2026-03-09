using MediatR;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.Domain.Common;
using src.Domain.Errors.EntityErrors;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.GetMataKuliahDetail;

internal sealed class GetMataKuliahDetailQueryHandler
    : IRequestHandler<GetMataKuliahDetailQuery, Result<MataKuliahDetailDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetMataKuliahDetailQueryHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result<MataKuliahDetailDto>> Handle(
        GetMataKuliahDetailQuery request, 
        CancellationToken cancellationToken)
    {
        var mataKuliah = await _dbContext.MataKuliah
            .AsNoTracking()
            .FirstOrDefaultAsync(mk => mk.Id == request.MataKuliahId, cancellationToken);
        if (mataKuliah is null)
            return Result<MataKuliahDetailDto>
                .Failure(MataKuliahErrors.MataKuliahWithIdNotFound(request.MataKuliahId));

        return Result<MataKuliahDetailDto>.Success(MataKuliahDetailDto.FromDomain(mataKuliah));
    }
}