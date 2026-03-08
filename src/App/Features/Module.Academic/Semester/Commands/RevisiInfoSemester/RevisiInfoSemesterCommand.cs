using MediatR;
using src.Domain.Common;
using src.Domain.Enums;

namespace src.App.Features.ModuleKuliah.Semester.Commands.RevisiInfoSemester;
public record RevisiInfoSemesterCommand : IRequest<Result>
{
    public Guid SemesterId { get; init; }
    
    public SemesterPeriod SemesterPeriod { get; init; } 

    public int Tahun { get; init; }

    public string TahunAjaran { get; init; } = null!;
}