namespace Celestials.Core.Errors;

public static class ErrorCodes
{
    public const string VALIDATION_REQUIRED = "validation.required";
    public const string VALIDATION_OUT_OF_RANGE = "validation.out_of_range";
    public const string VALIDATION_INVALID_FORMAT = "validation.invalid_format";
    public const string VALIDATION_NAME_EMPTY = "validation.name.empty";
    public const string VALIDATION_NAME_TOO_LONG = "validation.name.too_long";
    public const string VALIDATION_DESCRIPTION_TOO_LONG = "validation.description.too_long";
    public const string VALIDATION_FLAGS_EMPTY = "validation.flags.empty";
    public const string VALIDATION_ID_INVALID = "validation.id.invalid";
    public const string VALIDATION_OVERWRITE_NO_EFFECT = "validation.overwrite.no_effect";

    public const string PERMISSION_DENIED = "permission.denied";
    public const string PERMISSION_GUILD_ONLY = "permission.guild_only";
    public const string PERMISSION_REQUIRES_GROUP_MEMBER = "permission.requires_group_member";
    public const string PERMISSION_REQUIRES_GROUP_MOD = "permission.requires_group_moderator";
    public const string PERMISSION_REQUIRES_GUILD_MOD = "permission.requires_guild_moderator";
    public const string PERMISSION_REQUIRES_GROUP_OWNER = "permission.requires_group_owner";
    public const string PERMISSION_REQUIRES_GUILD_OWNER = "permission.requires_guild_owner";

    public const string NOT_FOUND_GROUP = "not_found.group";
    public const string NOT_FOUND_MEMBER = "not_found.member";
    public const string NOT_FOUND_OVERWRITE = "not_found.overwrite";
    public const string NOT_FOUND_CHANNEL = "not_found.channel";
    public const string NOT_FOUND_GUILD = "not_found.guild";

    public const string CONFLICT_DUPLICATE_GROUP_NAME = "conflict.duplicate_group_name";
    public const string CONFLICT_MEMBER_ALREADY_EXISTS = "conflict.member_exists";
    public const string CONFLICT_CHANNEL_ALREADY_EXISTS = "conflict.channel_exists";
    public const string CONFLICT_GLOBAL_LOG_EXISTS = "conflict.global_log_exists";
    public const string CONFLICT_GROUP_LOG_EXISTS = "conflict.group_log_exists";
    public const string CONFLICT_GROUP_DELETED = "conflict.group_deleted";
    public const string CONFLICT_GROUP_NOT_DELETED = "conflict.group_not_deleted";
    public const string CONFLICT_OWNER_CANNOT_BE_REMOVED = "conflict.owner_removal";
    public const string CONFLICT_TRANSFER_TO_NON_MEMBER = "conflict.transfer_non_member";

    public const string RATE_LIMIT_GUILD = "rate_limit.guild";
    public const string RATE_LIMIT_USER_CONCURRENCY = "rate_limit.user_concurrency";
    public const string RATE_LIMIT_DEDUPE = "rate_limit.duplicate_request";

    public const string TIMEOUT_REQUEST = "timeout.request";

    public const string INTERNAL_UNEXPECTED = "internal.unexpected";
    public const string INTERNAL_DB = "internal.database";
    public const string INTERNAL_CACHE = "internal.cache";
    public const string INTERNAL_DISPATCH = "internal.dispatch";
    public const string INTERNAL_DISCORD_API = "internal.discord_api";
}
