using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.Materi.GetMateriMetadataList;

public record GetMateriMetadataListQuery : IRequest<Result<IReadOnlyList<MateriMetadataDto>>>
{
    public Guid MataKuliahId { get; init; }

    public Guid MateriId { get; init; }
}