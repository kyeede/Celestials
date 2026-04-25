using Celestials.Core.Entities.Guilds;
using Celestials.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Celestials.Infrastructure.Persistence.Configurations;

internal sealed class GuildConfiguration : IEntityTypeConfiguration<Guild>
{
    public void Configure(EntityTypeBuilder<Guild> builder)
    {
        builder.ToTable("Guilds");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever().HasSnowflakeConversion();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.IconUrl).HasMaxLength(2048);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.DeletedAt);
        builder.Property(x => x.CreatedBy).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.UpdatedBy).HasNullableSnowflakeConversion();
        builder.Property(x => x.DeletedBy).HasNullableSnowflakeConversion();
    }
}
