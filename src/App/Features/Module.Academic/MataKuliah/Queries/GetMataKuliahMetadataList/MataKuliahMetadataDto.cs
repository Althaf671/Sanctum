using src.Domain.ValueObjects;
using MataKuliahEntity = src.Domain.Entities.MataKuliahAggregate.MataKuliah;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.GetMataKuliahMetadataList;

public record MataKuliahMetadataDto(
    Guid MataKuliahId,
    string KodeMataKuliah,
    string NamaMataKuliah,
    WaktuKuliah WaktuKuliah,
    string RuangKuliah
);