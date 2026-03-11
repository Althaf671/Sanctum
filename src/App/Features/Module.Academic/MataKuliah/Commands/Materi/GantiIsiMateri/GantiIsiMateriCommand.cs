using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.GantiIsiMateri;
public record GantiIsiMateriCommand : IRequest<Result>
{
    public Guid MataKuliahId { get; init; }
    
    public Guid MateriId { get; init; }

    public string OriginalFileUrl { get; init; } = null!;

    public string RingkasanMateri { get; init; } = null!;
}