using Microsoft.AspNetCore.Identity;
using src.Modules.AcademicDomain.Enums;
using src.SharedKernel.Domain.ValueObjects;


namespace src.Infrastructure.Identity;
public sealed class ApplicationUser : IdentityUser
{
    public Guid JurusanId { get; private set; }

    public Url GithubURL { get; private set; } = null!;

    public Url LinkedinURL { get; private set; } = null!;

    public Url? InstagramURL { get; private set; }

    public Url? SpotifyURL { get; private set; }

    public SemesterLevel Semester { get; private set; }
}