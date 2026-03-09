using src.Domain.ValueObjects;
using MataKuliahEntity = src.Domain.Entities.MataKuliahAggregate.MataKuliah;

namespace src.App.Features.ModuleKuliah.MataKuliah.Queries.GetMataKuliahDetail;

public record MataKuliahDetailDto(
    Guid MataKuliahId,
    string KodeMataKuliah,
    string NamaMataKuliah,
    int Sks,
    WaktuKuliah WaktuKuliah,
    string RuangKuliah,
    string DosenPengampu,
    Url LinkFolder,
    DateTime? UpdatedAt,
    DateTime CreatedAt
)
{
    public static MataKuliahDetailDto FromDomain(MataKuliahEntity mataKuliah)
        => new (
            mataKuliah.Id,
            mataKuliah.KodeMataKuliah,
            mataKuliah.NamaMataKuliah,
            mataKuliah.Sks,
            mataKuliah.WaktuKuliah,
            mataKuliah.RuangKuliah,
            mataKuliah.DosenPengampu,
            mataKuliah.LinkFolder,
            mataKuliah.UpdatedAt,
            mataKuliah.CreatedAt
        );
}

