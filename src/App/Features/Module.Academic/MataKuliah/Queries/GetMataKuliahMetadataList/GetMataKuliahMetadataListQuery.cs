using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.GetMataKuliahMetadataList;

public record GetMataKuliahMetadataListQuery : IRequest<Result<IReadOnlyList<MataKuliahMetadataDto>>>;