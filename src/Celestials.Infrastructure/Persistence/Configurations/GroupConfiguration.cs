using Celestials.Core.Entities.Groups;
using Celestials.Core.Entities.Guilds;
using Celestials.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Celestials.Infrastructure.Persistence.Configurations;

internal sealed class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever().HasSnowflakeConversion();
        builder.Property(x => x.GuildId).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.OwnerId).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.DeletedAt);
        builder.Property(x => x.CreatedBy).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.UpdatedBy).HasNullableSnowflakeConversion();
        builder.Property(x => x.DeletedBy).HasNullableSnowflakeConversion();

        builder.HasOne<Guild>().WithMany().HasForeignKey(x => x.GuildId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.GuildId, x.Name }).IsUnique();
    }
}
