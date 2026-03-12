using Microsoft.EntityFrameworkCore;
using src.Modules.AcademicDomain.Entities.MataKuliahAggregate;
using src.Modules.AcademicDomain.Interfaces;

namespace src.Infrastructure.Persistance.Repos;

public class MataKuliahRepository : IMataKuliahRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MataKuliahRepository(ApplicationDbContext context) =>
        _dbContext = context;


    public async Task<MataKuliah?> GetByIdAsync(Guid mataKuliahId, CancellationToken cancellationToken)
    {
        var mataKuliah = await _dbContext.MataKuliah
            .FirstOrDefaultAsync(mk => mk.Id == mataKuliahId, cancellationToken);
        if (mataKuliah is null)
            return null;

        return mataKuliah;
    }
    
    public async Task<MataKuliah?> GetWithMateriByIdAsync(
        Guid mataKuliahId, 
        Guid materiId, 
        CancellationToken cancellationToken)
    {
        return await _dbContext.MataKuliah
            .Include(mk => mk.Materi.Where(m => m.Id == materiId))
            .FirstOrDefaultAsync(mk => mk.Id == mataKuliahId, cancellationToken);
    }

    public async Task<MataKuliah?> GetMateriAndTugasByIdAsync(
        Guid mataKuliahId, 
        Guid materiId,
        Guid tugasId,
        CancellationToken cancellationToken)
    {
        return await _dbContext.MataKuliah
            .Include(mk => mk.Materi.Where(m => m.Id == materiId))
                .ThenInclude(m => m.Tugas.Where(t => t.Id == tugasId))
            .FirstOrDefaultAsync(mk => mk.Id == mataKuliahId, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}