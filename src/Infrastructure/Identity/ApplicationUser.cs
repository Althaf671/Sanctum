using Microsoft.AspNetCore.Identity;
using src.Domain.Enums;

namespace src.Infrastructure.Identity;
public sealed class ApplicationUser : IdentityUser
{
    public Guid JurusanId { get; private set; }

    public string GithubURL { get; private set; } = string.Empty;

    public string LinkedinURL { get; private set; } = string.Empty;

    public string? InstagramURL { get; private set; }

    public string? SpotifyURL { get; private set; }

    public Semester Semester { get; private set; }
}