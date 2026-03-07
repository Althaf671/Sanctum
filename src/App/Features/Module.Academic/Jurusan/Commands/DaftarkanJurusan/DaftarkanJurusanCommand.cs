using MediatR;
using src.Domain.Common;
using src.Domain.Enums;

namespace src.App.Features.ModuleKuliah.Jurusan.Commands.DaftarkanJurusan;
public record DaftarkanJurusanCommand : IRequest<Result>
{
    public Guid Id { get; init; }

    public string KodeJurusan { get; init; } = null!;

    public string NamaJurusan { get; init; } = null!;

    public string NamaFakultas { get; init; } = null!;

    public Jenjang Jenjang { get; init; } 

    public Akreditasi Akreditasi { get; init; } 
}