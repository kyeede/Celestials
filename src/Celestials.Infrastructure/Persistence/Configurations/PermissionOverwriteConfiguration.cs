using Celestials.Core.Entities.Groups;
using Celestials.Core.Entities.Guilds;
using Celestials.Core.Entities.Permissions;
using Celestials.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Celestials.Infrastructure.Persistence.Configurations;

internal sealed class PermissionOverwriteConfiguration : IEntityTypeConfiguration<PermissionOverwrite>
{
    public void Configure(EntityTypeBuilder<PermissionOverwrite> builder)
    {
        builder.ToTable(
            "PermissionOverwrites",
            tableBuilder =>
            {
                tableBuilder.HasCheckConstraint("CK_PermissionOverwrites_AllowedDeniedNoOverlap", "(Allowed & Denied) = 0");
            }
        );

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever().HasSnowflakeConversion();
        builder.Property(x => x.GuildId).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.GroupId).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.Scope).IsRequired();
        builder
            .Property(x => x.Allowed)
            .IsRequired()
            .HasConversion(toProvider => unchecked((long)toProvider), fromProvider => unchecked((PermissionFlags)fromProvider));
        builder
            .Property(x => x.Denied)
            .IsRequired()
            .HasConversion(toProvider => unchecked((long)toProvider), fromProvider => unchecked((PermissionFlags)fromProvider));
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.DeletedAt);
        builder.Property(x => x.CreatedBy).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.UpdatedBy).HasNullableSnowflakeConversion();
        builder.Property(x => x.DeletedBy).HasNullableSnowflakeConversion();

        builder.HasOne<Guild>().WithMany().HasForeignKey(x => x.GuildId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Group>().WithMany().HasForeignKey(x => x.GroupId).OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(x => new
            {
                x.GuildId,
                x.GroupId,
                x.Scope,
            })
            .IsUnique();
    }
}
