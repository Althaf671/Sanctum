using MediatR;
using src.Modules.AcademicDomain.Enums;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Commands.Materi.TambahMateri;
public record TambahMateriCommand : IRequest<Result<Guid>>
{
    public Guid MataKuliahId { get; init; }
    public string JudulMateri { get; init; } = null!;

    public string OriginalFileUrl { get; init; } = null!;

    public string RingkasanMateri { get; init; } = null!;

    public TipeMateri TipeMateri { get; init; } 

    public int PertemuanKe { get; init; } 
}