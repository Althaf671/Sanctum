using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Queries.GetMataKuliahMetadataList;

public record GetMataKuliahMetadataListQuery : IRequest<Result<IReadOnlyList<MataKuliahMetadataDto>>>;