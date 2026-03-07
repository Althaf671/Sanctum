using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Domain.ValueObjects;
using src.Infrastructure.Identity;

namespace src.Infrastructure.Persistance.Configs;

public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.JurusanId)
            .IsRequired();

        builder.Property(u => u.GithubURL)
            .HasConversion(
                url => url.Value,
                value => Url.Create(value).Value!
            )
            .HasColumnName("LinkGithub")
            .HasMaxLength(2048)
            .IsRequired();

        builder.Property(u => u.LinkedinURL)
            .HasConversion(
                url => url.Value,
                value => Url.Create(value).Value!
            )
            .HasColumnName("LinkLinkedin")
            .HasMaxLength(2048)
            .IsRequired();

        builder.Property(u => u.InstagramURL)
            .HasConversion(
                url => url == null ? null : url.Value,
                value => value == null ? null : Url.Create(value).Value!
            )
            .HasColumnName("LinkInstagram")
            .HasMaxLength(2048)
            .IsRequired(false);

        builder.Property(u => u.SpotifyURL)
            .HasConversion(
                url => url == null ? null : url.Value,
                value => value == null ? null : Url.Create(value).Value!
            )
            .HasColumnName("LinkSpotify")
            .HasMaxLength(2048)
            .IsRequired(false);
    }
}