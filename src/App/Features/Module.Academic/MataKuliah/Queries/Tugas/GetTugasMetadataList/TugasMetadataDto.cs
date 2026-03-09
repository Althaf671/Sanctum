namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.Tugas.GetTugasMetadataList;

public record TugasMetadataDto(
    Guid TugasId,
    string JudulTugas,
    bool IsTugasDikumpul
);