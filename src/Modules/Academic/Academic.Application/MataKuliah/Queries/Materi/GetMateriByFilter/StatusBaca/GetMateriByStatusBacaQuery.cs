using MediatR;
using src.Modules.Academic.App.MataKuliah.Queries.Materi.GetMateriMetadataList;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Queries.Materi.GetMateriByFilter.StatusBaca;

public record GetMateriByStatusBacaQuery : IRequest<Result<IReadOnlyList<MateriMetadataDto>>>
{
    public bool IsSudahDibaca { get; init; } 
}