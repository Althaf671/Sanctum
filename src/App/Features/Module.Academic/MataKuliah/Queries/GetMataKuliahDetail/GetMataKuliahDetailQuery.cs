using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.GetMataKuliahDetail;

public record GetMataKuliahDetailQuery : IRequest<Result<MataKuliahDetailDto>>
{
    public Guid MataKuliahId { get; init; }
}