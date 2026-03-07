using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.Semester.Commands.RevisiInfoSemester;
public record RevisiInfoSemesterCommand : IRequest<Result>
{
    public Guid SemesterId { get; init; }
    
    public DateOnly MasaKuliahStart { get; init; } 

    public DateOnly MasaKuliahEnd { get; init; } 

    public string TahunAjaran { get; init; } = null!;
}