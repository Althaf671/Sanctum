
using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.ValueObjects;
using MataKuliahEntity = src.Modules.AcademicDomain.Entities.MataKuliahAggregate.MataKuliah;

namespace src.Modules.Academic.App.MataKuliah.Queries.GetMataKuliahDetail;

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

