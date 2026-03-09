using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.Semester.Queries.GetDetailSemester;

public record GetDetailSemesterQuery : IRequest<Result<SemesterDetailDto>>
{
    public Guid SemesterId { get; init; }
}