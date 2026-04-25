using Celestials.Core.Entities.Guilds;
using Celestials.Core.Entities.Permissions;
using Celestials.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Celestials.Infrastructure.Persistence.Configurations;

internal sealed class GuildMemberConfiguration : IEntityTypeConfiguration<GuildMember>
{
    public void Configure(EntityTypeBuilder<GuildMember> builder)
    {
        builder.ToTable("GuildMembers");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever().HasSnowflakeConversion();
        builder.Property(x => x.GuildId).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.UserId).IsRequired().HasSnowflakeConversion();
        builder
            .Property(x => x.Permissions)
            .IsRequired()
            .HasConversion(toProvider => unchecked((long)toProvider), fromProvider => unchecked((PermissionFlags)fromProvider));
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.DeletedAt);
        builder.Property(x => x.CreatedBy).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.UpdatedBy).HasNullableSnowflakeConversion();
        builder.Property(x => x.DeletedBy).HasNullableSnowflakeConversion();

        builder.Ignore(x => x.Roles);

        builder.HasOne<Guild>().WithMany().HasForeignKey(x => x.GuildId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.GuildId, x.UserId }).IsUnique();
    }
}
