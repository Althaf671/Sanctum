using MediatR;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.MataKuliah.Queries.Tugas.GetTugasMetadataList;

public record GetTugasMetadataListQuery(Guid MateriId) 
    : IRequest<Result<IReadOnlyList<TugasMetadataDto>>>;