using src.Modules.AcademicDomain.ValueObjects;

namespace src.Modules.Academic.App.MataKuliah.Queries.GetMataKuliahMetadataList;

public record MataKuliahMetadataDto(
    Guid MataKuliahId,
    string KodeMataKuliah,
    string NamaMataKuliah,
    WaktuKuliah WaktuKuliah,
    string RuangKuliah
);