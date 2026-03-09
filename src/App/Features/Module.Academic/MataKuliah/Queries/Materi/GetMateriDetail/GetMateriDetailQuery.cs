using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.Materi.GetMateriDetail;

public record GetMaterDetailQuery : IRequest<Result<MateriDetailDto>>
{
    public Guid MataKuliahId { get; init; }
    public Guid MateriId { get; init; }
}