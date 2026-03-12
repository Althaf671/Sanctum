using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Modules.AcademicDomain.Entities.MataKuliahAggregate;
using src.SharedKernel.Domain.ValueObjects;

namespace src.Infrastructure.Persistance.Configs;

public class MataKuliahConfiguration : IEntityTypeConfiguration<MataKuliah>
{
    public void Configure(EntityTypeBuilder<MataKuliah> builder)
    {
        builder.ToTable("MataKuliah");
        builder.HasKey(mk => mk.Id);
        
        builder.Property(mk => mk.KodeMataKuliah)
            .HasMaxLength(40)
            .IsRequired();
        
        builder.Property(mk => mk.NamaMataKuliah)
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(mk => mk.Sks)
            .IsRequired();

        builder.OwnsOne(mk => mk.WaktuKuliah, wk =>
        {
            wk.Property(wk => wk.Tanggal)
                .HasColumnName("WaktuKuliah_Tanggal")
                .HasColumnType("date")
                .IsRequired();

            wk.Property(wk => wk.JamMulai)
                .HasColumnName("WaktuKuliah_JamMulai")
                .HasColumnType("time")
                .IsRequired();

            wk.Property(wk => wk.JamBerakhir)
                .HasColumnName("WaktuKuloah_JamBerakhir")
                .HasColumnType("time")
                .IsRequired();
        });

        builder.Property(mk => mk.RuangKuliah)
            .IsRequired();

        builder.Property(mk => mk.DosenPengampu)
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(mk => mk.LinkFolder)
            .HasConversion(
                url => url.Value,
                value => Url.Create(value).Value!
            )
            .HasColumnName("LinkFolder")
            .HasMaxLength(2048)
            .IsRequired();

        builder.Property(j => j.UpdatedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired(false);

        builder.Property(j => j.CreatedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.HasMany(mk => mk.Materi)
            .WithOne(m => m.MataKuliah)
            .HasForeignKey(m => m.MataKuliahId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}