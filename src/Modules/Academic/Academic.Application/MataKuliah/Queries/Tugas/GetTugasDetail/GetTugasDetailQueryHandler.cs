using MediatR;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Queries.Tugas.GetTugasDetail;

internal sealed class GetTugasDetailQueryHandler
    : IRequestHandler<GetTugasDetailQuery, Result<TugasDetailDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetTugasDetailQueryHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result<TugasDetailDto>> Handle(
        GetTugasDetailQuery request, 
        CancellationToken cancellationToken)
    {
        var tugas = await _dbContext.Tugas
            .AsNoTracking()
            .Where(t => t.MateriId == request.MateriId)
            .Where(t => t.Id == request.TugasId)
            .FirstOrDefaultAsync(cancellationToken);
        if (tugas is null)
            return Result<TugasDetailDto>
                .Failure(TugasErrors.TugasWithIdNotFound(request.TugasId));

        return Result<TugasDetailDto>.Success(TugasDetailDto.FromDomain(tugas));
    }
}