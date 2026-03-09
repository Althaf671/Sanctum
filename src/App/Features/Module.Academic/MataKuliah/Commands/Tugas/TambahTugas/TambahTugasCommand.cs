using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Tugas.TambahTugas;

public record TambahTugasCommand : IRequest<Result<Guid>>
{
    public Guid MataKuliahId { get; init; }
    
    public Guid MateriId { get; init; }

    public string JudulTugas { get; init; } = null!;

    public string UrlLinkPengerjaanTugas { get; init; } = null!;

    public string UrlLinkPengumpulanTugas { get; init; } = null!;
}