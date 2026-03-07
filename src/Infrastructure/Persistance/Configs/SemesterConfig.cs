using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Domain.Entities.SemesterAggregate;

namespace src.Infrastructure.Persistance.Configs;

public class SemesterConfiguration : IEntityTypeConfiguration<Semester>
{
    public void Configure(EntityTypeBuilder<Semester> builder)
    {
        builder.ToTable("Semester");
        builder.HasKey(s => s.Id);

        builder.OwnsOne(s => s.MasaKuliah, ms =>
        {
            ms.Property(m => m.Start)
              .HasColumnName("MasaKuliah_Start")
              .HasColumnType("date")
              .IsRequired();

            ms.Property(m => m.End)
              .HasColumnName("MasaKuliah_End")
              .HasColumnType("date")
              .IsRequired();
        });

        builder.Property(s => s.TahunAjaran)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(s => s.CreatedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired();
    }
}