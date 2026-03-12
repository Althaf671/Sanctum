using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.Semester.Queries.GetDetailSemester;

public record GetDetailSemesterQuery : IRequest<Result<SemesterDetailDto>>
{
    public Guid SemesterId { get; init; }
}