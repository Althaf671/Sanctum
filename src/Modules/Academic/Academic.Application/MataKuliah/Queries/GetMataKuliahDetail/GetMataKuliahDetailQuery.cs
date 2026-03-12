using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Queries.GetMataKuliahDetail;

public record GetMataKuliahDetailQuery(Guid MataKuliahId ) 
    : IRequest<Result<MataKuliahDetailDto>>;
