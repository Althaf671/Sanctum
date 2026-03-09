using src.Domain.ValueObjects;
using MataKuliahEntity = src.Domain.Entities.MataKuliahAggregate.MataKuliah;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.GetMataKuliahMetadataList;

public record MataKuliahMetadataListDto(
    Guid MataKuliahId,
    string KodeMataKuliah,
    string NamaMataKuliah,
    WaktuKuliah WaktuKuliah,
    string RuangKuliah
)
{
    public static MataKuliahMetadataListDto FromDomain(MataKuliahEntity mataKuliah)
        => new(
            mataKuliah.Id,
            mataKuliah.KodeMataKuliah,
            mataKuliah.NamaMataKuliah,
            mataKuliah.WaktuKuliah,
            mataKuliah.RuangKuliah
        );
}