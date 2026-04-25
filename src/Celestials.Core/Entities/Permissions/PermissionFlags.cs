namespace Celestials.Core.Entities.Permissions;

[Flags]
public enum PermissionFlags : ulong
{
    None = 0,

    ViewGroups = 1UL << 0,
    ViewMembers = 1UL << 1,
    ViewRoles = 1UL << 2,
    ViewChannels = 1UL << 3,
    ViewPermissions = 1UL << 4,
    ViewAuditLogs = 1UL << 5,

    AddMembers = 1UL << 6,
    RemoveMembers = 1UL << 7,
    KickMembers = 1UL << 8,
    BanMembers = 1UL << 9,
    UnbanMembers = 1UL << 10,

    AddRoles = 1UL << 11,
    RemoveRoles = 1UL << 12,
    AssignRoles = 1UL << 13,
    UnassignRoles = 1UL << 14,

    AddChannels = 1UL << 15,
    RemoveChannels = 1UL << 16,
    ManageChannels = 1UL << 17,

    AddOverwrites = 1UL << 18,
    RemoveOverwrites = 1UL << 19,
    ManagePermissions = 1UL << 20,

    Administrator = 1UL << 63,
}
