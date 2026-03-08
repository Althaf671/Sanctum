using MediatR;
using src.Domain.Common;
using src.Domain.Enums;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.TambahMateri;
public record TambahMateriCommand : IRequest<Result>
{
    public Guid MataKuliahId { get; init; }
    public string JudulMateri { get; init; } = null!;

    public string OriginalFileUrl { get; init; } = null!;

    public string RingkasanMateri { get; init; } = null!;

    public TipeMateri TipeMateri { get; init; } 

    public int PertemuanKe { get; init; } 
}