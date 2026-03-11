using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.GetMataKuliahDetail;

public record GetMataKuliahDetailQuery(Guid MataKuliahId ) 
    : IRequest<Result<MataKuliahDetailDto>>;
