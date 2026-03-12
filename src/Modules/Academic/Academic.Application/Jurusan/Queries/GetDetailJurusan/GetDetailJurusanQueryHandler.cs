using MediatR;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.Jurusan.Queries.GetDetailJurusan;

internal sealed class GetDetailJurusanQueryHandler
    : IRequestHandler<GetDetailJurusanQuery, Result<JurusanDetailDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetDetailJurusanQueryHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result<JurusanDetailDto>> Handle(
        GetDetailJurusanQuery request, 
        CancellationToken cancellationToken)
    {
        var jurusan = await _dbContext.Jurusan
            .AsNoTracking()
            .FirstOrDefaultAsync(j => j.Id == request.JurusanId, cancellationToken);
        if (jurusan is null)
            return Result<JurusanDetailDto>
                .Failure(JurusanErrors.JurusanWithIdNotFound(request.JurusanId));

        return Result<JurusanDetailDto>.Success(JurusanDetailDto.FromDomain(jurusan));
    }
}