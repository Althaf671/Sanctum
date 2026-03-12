using MediatR;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.Semester.Queries.GetDetailSemester;

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