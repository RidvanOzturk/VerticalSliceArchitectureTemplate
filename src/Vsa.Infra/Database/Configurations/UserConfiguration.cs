using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vsa.Domain.Database;
using Vsa.Domain.Database.Enums;

namespace Vsa.Infra.Database.Configurations;
public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.Surname)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.Sex)
       .HasConversion<string>();

        builder.HasData(
            new User
            {
                Id = 1,
                Name = "Rico",
                Surname = "Ozturk",
                Email = "oztrico1@gmail.com",
                Age = 24,
                Sex = Sex.Male
            },
            new User
            {
                Id = 2,
                Name = "Bacu",
                Surname = "Ozturk",
                Email = "fbr@gmail.com",
                Age = 26,
                Sex = Sex.Male
            },
            new User
            {
                Id = 3,
                Name = "Furkan",
                Surname = "Ozturk",
                Email = "frkn@gmail.com",
                Age = 31,
                Sex = Sex.Male
            }
        );
    }
}
