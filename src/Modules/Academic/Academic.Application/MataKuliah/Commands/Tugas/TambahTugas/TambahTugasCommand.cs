using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Commands.Tugas.TambahTugas;

public record TambahTugasCommand : IRequest<Result<Guid>>
{
    public Guid MataKuliahId { get; init; }
    
    public Guid MateriId { get; init; }

    public string JudulTugas { get; init; } = null!;

    public string UrlLinkPengerjaanTugas { get; init; } = null!;

    public string UrlLinkPengumpulanTugas { get; init; } = null!;
}