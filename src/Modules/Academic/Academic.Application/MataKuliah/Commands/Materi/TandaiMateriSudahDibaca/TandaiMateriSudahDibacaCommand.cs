using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Commands.Materi.TandaiMateriSudahDibaca;
public record TandaiMateriSudahDibacaCommand : IRequest<Result>
{
    public Guid MataKuliahId { get; init; }
    
    public Guid MateriId { get; init; }
}