using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Queries.Materi.GetMateriDetail;

public record GetMaterDetailQuery(
    Guid MateriId, Guid MataKuliahId) : IRequest<Result<MateriDetailDto>>;