using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.Semester.Commands.DaftarkanSemester;

public record DaftarkanSemesterCommand : IRequest<Result>
{
    public DateOnly MasaKuliahStart { get; init; } 

    public DateOnly MasaKuliahEnd { get; init; } 

    public string TahunAjaran { get; init; } = null!;
}