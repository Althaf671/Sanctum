using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Domain.Entities;

namespace src.Infrastructure.Persistance.Configs;

public class JurusanConfiguration : IEntityTypeConfiguration<Jurusan>
{
    public void Configure(EntityTypeBuilder<Jurusan> builder)
    {
        builder.ToTable("Jurusan");
        builder.HasKey(j => j.Id);

        builder.Property(j => j.KodeJurusan)
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(j => j.NamaJurusan)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(j => j.NamaFakultas)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(j => j.Jenjang)
            .HasConversion<string>()
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(j => j.Akreditasi)
            .HasConversion<string>()
            .HasMaxLength(12)
            .IsRequired();

        builder.Property(j => j.UpdatedAt)
            .HasColumnType("timestamp with time zone") // for psql to set it as timezone
            .IsRequired(false);

        builder.Property(j => j.CreatedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired();
    }
}