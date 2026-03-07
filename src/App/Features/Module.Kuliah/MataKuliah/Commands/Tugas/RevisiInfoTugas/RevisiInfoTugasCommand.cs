using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Tugas.RevisiInfoTugas;

public record RevisiInfoTugasCommand : IRequest<Result>
{
    public Guid MateriId { get; init; }

    public Guid TugasId { get; init; }

    public string JudulTugas { get; init; } = null!;

    public string UrlLinkPengerjaanTugas { get; init; } = null!;

    public string UrlLinkPengumpulanTugas { get; init; } = null!;
}