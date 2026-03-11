using MediatR;
using src.Domain.Common;
using src.Domain.Enums;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.RevisiInfoMateri;
public record RevisiInfoMateriCommand(
    Guid MateriId, 
    Guid MataKuliahId, 
    string JudulMateri,
    int PertemuanKe, 
    TipeMateri TipeMateri) : IRequest<Result>;
