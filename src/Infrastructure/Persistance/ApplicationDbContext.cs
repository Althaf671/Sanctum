using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.Domain.Entities;
using src.Domain.Entities.MataKuliahAggregate;
using src.Domain.Entities.SemesterAggregate;
using src.Infrastructure.Identity;

namespace src.Infrastructure.Persistance;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {}

    public DbSet<Semester> Semester => Set<Semester>();

    public DbSet<Jurusan> Jurusan => Set<Jurusan>();

    public DbSet<MataKuliah> MataKuliah => Set<MataKuliah>();

    public DbSet<Materi> Materi => Set<Materi>();

    public DbSet<Tugas> Tugas => Set<Tugas>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}