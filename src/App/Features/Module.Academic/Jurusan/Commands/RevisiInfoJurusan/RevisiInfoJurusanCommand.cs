using MediatR;
using src.Domain.Common;
using src.Domain.Enums;

namespace src.App.Features.ModuleKuliah.Jurusan.Commands.RevisiInfoJurusan;
public record RevisiInfoJurusanCommand : IRequest<Result>
{
    public Guid JurusanId { get; init; }

    public string KodeJurusan { get; init; } = null!;

    public string NamaJurusan { get; init; } = null!;

    public string NamaFakultas { get; init; } = null!;

    public Jenjang Jenjang { get; init; } 

    public Akreditasi Akreditasi { get; init; } 
}