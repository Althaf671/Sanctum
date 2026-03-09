using src.Domain.Enums;
using MateriEntity = src.Domain.Entities.MataKuliahAggregate.Materi;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.Materi.GetMateriMetadataList;

public record MateriMetadataDto(
    Guid MataKuliahId,
    Guid MateriId,
    string Judul,
    TipeMateri TipeMateri,
    bool IsSudahDibaca
);