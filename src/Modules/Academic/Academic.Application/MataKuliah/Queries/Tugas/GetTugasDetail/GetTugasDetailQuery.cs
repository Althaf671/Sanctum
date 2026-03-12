using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Queries.Tugas.GetTugasDetail;

public record GetTugasDetailQuery : IRequest<Result<TugasDetailDto>>
{
    public Guid MateriId { get; init; }

    public Guid TugasId { get; init; }
}