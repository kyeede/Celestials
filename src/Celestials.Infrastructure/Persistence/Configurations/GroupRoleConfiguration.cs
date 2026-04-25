using Celestials.Core.Entities.Groups;
using Celestials.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Celestials.Infrastructure.Persistence.Configurations;

internal sealed class GroupRoleConfiguration : IEntityTypeConfiguration<GroupRole>
{
    public void Configure(EntityTypeBuilder<GroupRole> builder)
    {
        builder.ToTable("GroupRoles");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever().HasSnowflakeConversion();
        builder.Property(x => x.GroupId).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.RoleId).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired().HasSnowflakeConversion();

        builder.HasOne<Group>().WithMany(x => x.Roles).HasForeignKey(x => x.GroupId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.GroupId, x.RoleId }).IsUnique();
    }
}
