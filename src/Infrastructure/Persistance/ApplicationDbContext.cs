using Microsoft.EntityFrameworkCore;

namespace src.Infrastructure.Persistance;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {}
}