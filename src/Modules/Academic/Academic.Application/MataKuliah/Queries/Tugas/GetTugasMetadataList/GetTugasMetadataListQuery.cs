using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Queries.Tugas.GetTugasMetadataList;

public record GetTugasMetadataListQuery : IRequest<Result<IReadOnlyList<TugasMetadataDto>>>
{
    public Guid MateriId { get; init; }
}