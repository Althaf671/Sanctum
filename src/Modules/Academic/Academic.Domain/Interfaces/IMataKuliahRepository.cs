using src.Modules.AcademicDomain.Entities.MataKuliahAggregate;

namespace src.Modules.AcademicDomain.Interfaces;
public interface IMataKuliahRepository
{
    Task<MataKuliah?> GetByIdAsync(Guid mataKuliahId, CancellationToken cancellationToken);

    Task<MataKuliah?> GetWithMateriByIdAsync(
        Guid mataKuliahId, Guid materiId, CancellationToken cancellationToken);
 
    Task<MataKuliah?> GetMateriAndTugasByIdAsync(
        Guid mataKuliahId, Guid materiId, Guid tugasId, CancellationToken cancellationToken);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}