using MediatR;
using src.Domain.Common;
using src.Domain.Enums;

namespace src.App.Features.ModuleKuliah.Semester.Commands.DaftarkanSemester;

public record DaftarkanSemesterCommand : IRequest<Result<Guid>>
{
    public SemesterPeriod SemesterPeriod { get; init; } 

    public int Tahun { get; init; }

    public string TahunAjaran { get; init; } = null!;
}