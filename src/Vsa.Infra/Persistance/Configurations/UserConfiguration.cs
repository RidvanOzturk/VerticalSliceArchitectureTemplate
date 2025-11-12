using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vsa.Domain.Users;

namespace Vsa.Infra.Persistance.Configurations;
public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> b)
    {
        // boş bırakıldı; isterse max length/unique eklenir
    }
}
