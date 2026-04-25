namespace Celestials.Core.Entities.Channels;

[Flags]
public enum ChannelFlags : ulong
{
    None = 0,

    GroupCreated = 1UL << 0,
    GroupDeleted = 1UL << 1,
    GroupUpdated = 1UL << 2,

    MemberAdded = 1UL << 3,
    MemberRemoved = 1UL << 4,
    MemberPromoted = 1UL << 5,
    MemberDemoted = 1UL << 6,

    RoleAdded = 1UL << 7,
    RoleRemoved = 1UL << 8,

    RoleAssigned = 1UL << 9,
    RoleRevoked = 1UL << 10,

    OverwriteCreated = 1UL << 11,
    OverwriteDeleted = 1UL << 12,
    OverwriteUpdated = 1UL << 13,

    LogChannelAdded = 1UL << 14,
    LogChannelRemoved = 1UL << 15,
    LogChannelUpdated = 1UL << 16,

    All =
        GroupCreated
        | GroupDeleted
        | GroupUpdated
        | MemberAdded
        | MemberRemoved
        | MemberPromoted
        | MemberDemoted
        | RoleAdded
        | RoleRemoved
        | RoleAssigned
        | RoleRevoked
        | OverwriteCreated
        | OverwriteDeleted
        | OverwriteUpdated
        | LogChannelAdded
        | LogChannelRemoved
        | LogChannelUpdated,
}
