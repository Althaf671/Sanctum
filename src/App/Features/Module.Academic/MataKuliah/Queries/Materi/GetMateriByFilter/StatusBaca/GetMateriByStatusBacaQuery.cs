using MediatR;
using src.App.Features.ModuleKuliah.MataKuliah.Queries.Materi.GetMateriMetadataList;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.Materi.GetMateriByFilter.StatusBaca;

public record GetMateriByStatusBacaQuery : IRequest<Result<IReadOnlyList<MateriMetadataDto>>>
{
    public bool IsSudahDibaca { get; init; } 
}