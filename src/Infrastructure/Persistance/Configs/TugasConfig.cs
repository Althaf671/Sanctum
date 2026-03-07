using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Domain.Entities.MataKuliahAggregate;
using src.Domain.ValueObjects;

namespace src.Infrastructure.Persistance.Configs;

public class TugasConfiguration : IEntityTypeConfiguration<Tugas>
{
    public void Configure(EntityTypeBuilder<Tugas> builder)
    {
        builder.ToTable("Tugas");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.JudulTugas)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(t => t.LinkPengerjaanTugas)
            .HasConversion(
                url => url.Value,
                value => Url.Create(value).Value!
            )
            .HasColumnName("LinkPengerjaanTugas")
            .HasMaxLength(2048)
            .IsRequired();

        builder.Property(t => t.LinkPengumpulanTugas)
            .HasConversion(
                url => url.Value,
                value => Url.Create(value).Value!
            )
            .HasColumnName("LinkPengumpulanTugas")
            .HasMaxLength(2048)
            .IsRequired();

        builder.Property(t => t.IsTugasDikumpul)
            .IsRequired();

        builder.Property( t => t.IsDeleted)
            .IsRequired();

        builder.Property(j => j.UpdatedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired(false);

        builder.Property(j => j.CreatedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired();
    }
}