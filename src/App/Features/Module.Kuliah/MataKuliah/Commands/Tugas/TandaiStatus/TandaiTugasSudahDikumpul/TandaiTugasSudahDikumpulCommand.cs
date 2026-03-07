using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Tugas.TandaiStatus.TandaiTugasSudahDikumpul;

public record TandaiTugasSudahDikumpulCommand : IRequest<Result>
{
    public Guid MateriId { get; init; }

    public Guid TugasId { get; init; }
}