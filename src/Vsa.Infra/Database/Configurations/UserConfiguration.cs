using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vsa.Domain.Database;

namespace Vsa.Infra.Database.Configurations;
public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(200);


        builder.HasData(
            new User
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
    }
}
