using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Vsa.Domain.Settings;
using Vsa.Domain.Users;

namespace Vsa.Infra.Persistance;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Setting> Settings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<User>()
            .HasData(new User
            {
                Id = 1,
                Name = "Rico",
                Email = "oztrico1@gmail.com"
            },
            new User
            {
                Id = 2,
                Name = "Bacu",
                Email = "fbr@gmail.com"
            },
            new User
            {
                Id = 3,
                Name = "Furkan",
                Email = "frkn@gmail.com"
            }
            );
        modelBuilder.Entity<Setting>()
            .HasData(new Setting
            {
                Id = 1,
                Key = "Support.Email",
                Value = "support@myapp.com"
            }
            );

        base.OnModelCreating(modelBuilder);
    }
}
