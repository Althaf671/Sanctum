using MediatR;
using src.Modules.AcademicDomain.Enums;
using src.SharedKernel.Domain.Common;


namespace src.Modules.Academic.App.Jurusan.Commands.DaftarkanJurusan;
public record DaftarkanJurusanCommand : IRequest<Result<Guid>>
{
    public string KodeJurusan { get; init; } = null!;

    public string NamaJurusan { get; init; } = null!;

    public string NamaFakultas { get; init; } = null!;

    public Jenjang Jenjang { get; init; } 

    public Akreditasi Akreditasi { get; init; } 
}