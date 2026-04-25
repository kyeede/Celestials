using Celestials.Core.Entities.Channels;
using Celestials.Core.Entities.Groups;
using Celestials.Core.Entities.Guilds;
using Celestials.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Celestials.Infrastructure.Persistence.Configurations;

internal sealed class LogChannelConfiguration : IEntityTypeConfiguration<LogChannel>
{
    public void Configure(EntityTypeBuilder<LogChannel> builder)
    {
        builder.ToTable(
            "LogChannels",
            tableBuilder =>
            {
                tableBuilder.HasCheckConstraint(
                    "CK_LogChannels_ScopeGroupConsistency",
                    "(Scope = 0 AND GroupId IS NULL) OR (Scope = 1 AND GroupId IS NOT NULL)"
                );
            }
        );

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever().HasSnowflakeConversion();
        builder.Property(x => x.GuildId).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.ChannelId).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.GroupId).HasNullableSnowflakeConversion();
        builder.Property(x => x.Scope).IsRequired();
        builder
            .Property(x => x.Flags)
            .IsRequired()
            .HasConversion(toProvider => unchecked((long)toProvider), fromProvider => unchecked((ChannelFlags)fromProvider));
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.DeletedAt);
        builder.Property(x => x.CreatedBy).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.UpdatedBy).HasNullableSnowflakeConversion();
        builder.Property(x => x.DeletedBy).HasNullableSnowflakeConversion();

        builder.HasOne<Guild>().WithMany().HasForeignKey(x => x.GuildId).OnDelete(DeleteBehavior.Restrict);

        // GroupId is optional — a Global log channel has no associated group.
        builder.HasOne<Group>().WithMany().HasForeignKey(x => x.GroupId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.GuildId, x.ChannelId }).IsUnique();
        builder
            .HasIndex(x => new
            {
                x.GuildId,
                x.Scope,
                x.GroupId,
            })
            .IsUnique();
    }
}
