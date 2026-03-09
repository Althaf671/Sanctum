using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.Tugas.GetTugasDetail;

public record GetTugasDetailQuery : IRequest<Result<TugasDetailDto>>
{
    public Guid MateriId { get; init; }

    public Guid TugasId { get; init; }
}