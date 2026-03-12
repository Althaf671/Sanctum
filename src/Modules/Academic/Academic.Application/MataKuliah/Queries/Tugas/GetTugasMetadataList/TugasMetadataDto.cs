namespace src.Modules.Academic.App.MataKuliah.Queries.Tugas.GetTugasMetadataList;

public record TugasMetadataDto(
    Guid TugasId,
    string JudulTugas,
    bool IsTugasDikumpul
);