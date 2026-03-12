using src.Modules.AcademicDomain.Enums;

namespace src.Modules.Academic.App.MataKuliah.Queries.Materi.GetMateriMetadataList;

public record MateriMetadataDto(
    Guid MataKuliahId,
    Guid MateriId,
    string Judul,
    TipeMateri TipeMateri,
    bool IsSudahDibaca
);