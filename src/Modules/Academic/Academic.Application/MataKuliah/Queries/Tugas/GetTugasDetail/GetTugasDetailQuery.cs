using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Queries.Tugas.GetTugasDetail;

public record GetTugasDetailQuery(Guid MateriId, Guid TugasId) 
    : IRequest<Result<TugasDetailDto>>;
