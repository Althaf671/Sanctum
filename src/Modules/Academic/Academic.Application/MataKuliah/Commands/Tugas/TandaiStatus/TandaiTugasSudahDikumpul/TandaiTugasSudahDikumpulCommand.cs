using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Commands.Tugas.TandaiStatus.TandaiTugasSudahDikumpul;

public record TandaiTugasSudahDikumpulCommand : IRequest<Result>
{
    public Guid MataKuliahId { get; init; }
    
    public Guid MateriId { get; init; }

    public Guid TugasId { get; init; }
}