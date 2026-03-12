using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.Infrastructure.Identity;
using src.Modules.AcademicDomain.Entities;
using src.Modules.AcademicDomain.Entities.MataKuliahAggregate;
using src.Modules.AcademicDomain.Entities.SemesterAggregate;

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