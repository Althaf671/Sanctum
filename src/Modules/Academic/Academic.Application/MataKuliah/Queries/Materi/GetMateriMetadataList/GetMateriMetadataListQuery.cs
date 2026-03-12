using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Queries.Materi.GetMateriMetadataList;

public record GetMateriMetadataListQuery(
    Guid MataKuliahId) : IRequest<Result<IReadOnlyList<MateriMetadataDto>>>;
