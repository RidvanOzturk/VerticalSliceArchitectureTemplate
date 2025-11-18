using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vsa.Domain.Database;

namespace Vsa.Infra.Database.Configurations;
public sealed class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Value)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.Key)
               .IsRequired()
               .HasMaxLength(200);

        builder.HasData(new Setting
         {
             Id = 1,
             Key = "Support.Email",
             Value = "support@myapp.com"
         }
            );
    }
}
