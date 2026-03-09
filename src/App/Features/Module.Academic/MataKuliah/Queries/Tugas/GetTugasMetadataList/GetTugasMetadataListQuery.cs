using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.Tugas.GetTugasMetadataList;

public record GetTugasMetadataListQuery : IRequest<Result<IReadOnlyList<TugasMetadataDto>>>
{
    public Guid MateriId { get; init; }
}