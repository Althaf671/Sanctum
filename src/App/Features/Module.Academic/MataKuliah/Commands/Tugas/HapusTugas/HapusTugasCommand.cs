using MediatR;
using src.Domain.Common;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Tugas.HapusTugas;

public record HapusTugasCommand : IRequest<Result>
{
    public Guid MateriId { get; init; }

    public Guid TugasId { get; init; }
}