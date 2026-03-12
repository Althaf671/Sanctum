using MediatR;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Queries.Materi.GetMateriDetail;

internal sealed class GetMateriDetailQueryHandler
    : IRequestHandler<GetMaterDetailQuery, Result<MateriDetailDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetMateriDetailQueryHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result<MateriDetailDto>> Handle(
        GetMaterDetailQuery request, 
        CancellationToken cancellationToken)
    {
        var materi = await _dbContext.Materi
            .AsNoTracking()
            .Where(m => m.MataKuliahId == request.MataKuliahId)
            .FirstOrDefaultAsync(m => m.Id == request.MateriId, cancellationToken);
        if (materi is null)
            return Result<MateriDetailDto>
                .Failure(MateriErrors.MateriWithIdNotFound(request.MateriId));

        return Result<MateriDetailDto>
            .Success(MateriDetailDto.FromDomain(materi));
    }
}