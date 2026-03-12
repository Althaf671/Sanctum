using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.AcademicDomain.Entities.MataKuliahAggregate;

namespace src.Infrastructure.Persistance.Configs;

public class MateriConfiguraton : IEntityTypeConfiguration<Materi>
{
    public void Configure(EntityTypeBuilder<Materi> builder)
    {
        builder.ToTable("Materi");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Judul)
            .IsRequired();

        builder.Property(m => m.PertemuanKe)
            .IsRequired();

        builder.OwnsOne(m => m.IsiMateri, im =>
        {
            im.OwnsOne(im => im.OriginalFileURL, url =>
            {
                url.Property(u => u.Value)
                    .HasColumnName("IsiMateri_OriginalPath")
                    .HasMaxLength(2048)
                    .IsRequired();
            });

            im.Property(im => im.Ringkasan)
                .HasColumnName("IsiMateri_Ringkasan")
                .HasMaxLength(500)
                .IsRequired();
        });

        builder.Property(m => m.TipeMateri)
            .HasConversion<string>()
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(m => m.IsSudahDibaca)
            .IsRequired();

        builder.Property(m => m.DibacaAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired(false);

        builder.Property(j => j.UpdatedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired(false);

        builder.Property(j => j.CreatedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.HasMany(m => m.Tugas)
            .WithOne(t => t.Materi)
            .HasForeignKey(t => t.MateriId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}