using Microsoft.EntityFrameworkCore;
using src.Modules.AcademicDomain.Entities;
using src.Modules.AcademicDomain.Entities.MataKuliahAggregate;
using src.Modules.AcademicDomain.Entities.SemesterAggregate;


namespace src.Infrastructure.Persistance;
public interface IApplicationDbContext
{
    public DbSet<Semester> Semester { get; }
    
    public DbSet<Jurusan> Jurusan { get; }

    public DbSet<MataKuliah> MataKuliah { get; }

    public DbSet<Materi> Materi { get; }

    public DbSet<Tugas> Tugas { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}