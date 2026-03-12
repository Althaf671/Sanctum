using MediatR;
using src.Modules.AcademicDomain.Enums;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.Semester.Commands.RevisiInfoSemester;
public record RevisiInfoSemesterCommand : IRequest<Result>
{
    public Guid SemesterId { get; init; }
    
    public SemesterPeriod SemesterPeriod { get; init; } 

    public int Tahun { get; init; }

    public string TahunAjaran { get; init; } = null!;
}