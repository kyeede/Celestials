namespace Celestials.Core.Options;

[Flags]
public enum RetryMode
{
    AlwaysFail = 0x0,
    RetryTimeouts = 0x1,
    RetryRatelimit = 0x4,
    Retry502 = 0x8,
    AlwaysRetry = RetryTimeouts | RetryRatelimit | Retry502,
}
