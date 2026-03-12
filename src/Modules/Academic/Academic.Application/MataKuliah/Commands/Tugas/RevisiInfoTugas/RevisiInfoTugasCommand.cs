using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Commands.Tugas.RevisiInfoTugas;

public record RevisiInfoTugasCommand : IRequest<Result>
{
    public Guid MataKuliahId { get; init; }
    
    public Guid MateriId { get; init; }

    public Guid TugasId { get; init; }

    public string JudulTugas { get; init; } = null!;

    public string UrlLinkPengerjaanTugas { get; init; } = null!;

    public string UrlLinkPengumpulanTugas { get; init; } = null!;
}