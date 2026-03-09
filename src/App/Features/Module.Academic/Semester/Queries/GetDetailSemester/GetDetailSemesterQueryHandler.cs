using MediatR;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.Domain.Common;
using src.Domain.Errors.EntityErrors;

namespace src.App.Features.ModuleKuliah.Semester.Queries.GetDetailSemester;

internal sealed class GetDetailSemesterQueryHandler
    : IRequestHandler<GetDetailSemesterQuery, Result<SemesterDetailDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetDetailSemesterQueryHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result<SemesterDetailDto>> Handle(
        GetDetailSemesterQuery request, 
        CancellationToken cancellationToken)
    {
        var semester = await _dbContext.Semester
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == request.SemesterId, cancellationToken);
        if (semester is null)
            return Result<SemesterDetailDto>
                .Failure(SemesterErrors.SemesterWithIdNotFound(request.SemesterId));

        return Result<SemesterDetailDto>.Success(SemesterDetailDto.FromDomain(semester));
    }
}