using Microsoft.EntityFrameworkCore;
using src.Domain.Entities;
using src.Domain.Entities.MataKuliahAggregate;
using src.Domain.Entities.SemesterAggregate;

namespace src.App.Common.Interfaces;
public interface IApplicationDbContext
{
    public DbSet<Semester> Semester { get; }
    
    public DbSet<Jurusan> Jurusan { get; }

    public DbSet<MataKuliah> MataKuliah { get; }

    public DbSet<Materi> Materi { get; }

    public DbSet<Tugas> Tugas { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}