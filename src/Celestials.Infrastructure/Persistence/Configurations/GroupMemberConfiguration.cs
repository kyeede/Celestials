using Celestials.Core.Entities.Groups;
using Celestials.Core.Entities.Permissions;
using Celestials.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Celestials.Infrastructure.Persistence.Configurations;

internal sealed class GroupMemberConfiguration : IEntityTypeConfiguration<GroupMember>
{
    public void Configure(EntityTypeBuilder<GroupMember> builder)
    {
        builder.ToTable("GroupMembers");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedNever().HasSnowflakeConversion();
        builder.Property(x => x.UserId).IsRequired().HasSnowflakeConversion();
        builder.Property(x => x.GroupId).IsRequired().HasSnowflakeConversion();
        builder
            .Property(x => x.Permissions)
            .IsRequired()
            .HasConversion(toProvider => unchecked((long)toProvider), fromProvider => unchecked((PermissionFlags)fromProvider));
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired().HasSnowflakeConversion();

        builder.HasOne<Group>().WithMany(x => x.Members).HasForeignKey(x => x.GroupId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.GroupId, x.UserId }).IsUnique();
    }
}
