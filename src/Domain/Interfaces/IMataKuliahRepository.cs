using src.Domain.Common;
using src.Domain.Entities.MataKuliahAggregate;

namespace src.Domain.Interfaces;
public interface IMataKuliahRepository
{
    Task<MataKuliah?> GetByIdAsync(Guid mataKuliahId, CancellationToken cancellationToken);

    Task<MataKuliah?> GetWithMateriByIdAsync(
        Guid mataKuliahId, Guid materiId, CancellationToken cancellationToken);
 
    Task<MataKuliah?> GetMateriAndTugasByIdAsync(
        Guid mataKuliahId, Guid materiId, Guid tugasId, CancellationToken cancellationToken);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}