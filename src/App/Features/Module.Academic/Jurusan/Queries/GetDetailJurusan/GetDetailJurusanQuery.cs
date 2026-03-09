using MediatR;
using src.App.Features.ModuleKuliah.Semester.Queries.GetDetailSemester;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.Jurusan.Queries.GetDetailJurusan;

public sealed record GetDetailJurusanQuery : IRequest<Result<JurusanDetailDto>>
{
    public Guid JurusanId { get; init; }
}