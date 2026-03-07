using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.TandaiMateriSudahDibaca;
public record TandaiMateriSudahDibacaCommand : IRequest<Result>
{
    public Guid MateriId { get; init; }
}