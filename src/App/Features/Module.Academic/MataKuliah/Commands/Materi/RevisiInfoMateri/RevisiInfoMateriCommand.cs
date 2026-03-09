using MediatR;
using src.Domain.Common;
using src.Domain.Enums;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.RevisiInfoMateri;
public record RevisiInfoMateriCommand : IRequest<Result>
{
    public Guid MataKuliahId { get; init; }
    public Guid MateriId { get; init; }

    public string JudulMateri { get; init; } = null!;

    public int PertemuanKe { get; init; } 

    public TipeMateri TipeMateri { get; init; } 
}