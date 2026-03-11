using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.Materi.GetMateriDetail;

public record GetMaterDetailQuery(
    Guid MateriId, Guid MataKuliahId) : IRequest<Result<MateriDetailDto>>;