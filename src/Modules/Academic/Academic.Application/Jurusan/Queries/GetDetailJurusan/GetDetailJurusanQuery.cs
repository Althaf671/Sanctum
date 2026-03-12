using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.Jurusan.Queries.GetDetailJurusan;

public sealed record GetDetailJurusanQuery(Guid JurusanId) 
    : IRequest<Result<JurusanDetailDto>>;