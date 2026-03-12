using MediatR;
using src.Modules.AcademicDomain.Enums;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Commands.Materi.RevisiInfoMateri;
public record RevisiInfoMateriCommand(
    Guid MateriId, 
    Guid MataKuliahId, 
    string JudulMateri,
    int PertemuanKe, 
    TipeMateri TipeMateri) : IRequest<Result>;
