using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vsa.Domain.Settings;
using Vsa.Domain.Users;

namespace Vsa.Infra.Persistance.Configurations;
public sealed class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> b)
    {
    }
}
