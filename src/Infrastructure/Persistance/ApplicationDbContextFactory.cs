using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace src.Infrastructure.Persistance;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        // Testing local db
        optionsBuilder.UseNpgsql(
            "Host=..;Port=..;Database=..;Username=postgres;Password=123test"
        );

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}