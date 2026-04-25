namespace Celestials.Core.Utilities;

public static class SnowflakeUtils
{
    public const long EPOCH = 1420070400000L;

    private const int TIMESTAMP_SHIFT = 22;
    private const int WORKER_ID_SHIFT = 17;
    private const int PROCESS_ID_SHIFT = 12;

    private const ulong TIMESTAMP_MASK = 0xFFFFFFFFFFC00000UL;
    private const ulong WORKER_MASK = 0x00000000003E0000UL;
    private const ulong PROCESS_MASK = 0x000000000001F000UL;
    private const ulong INCREMENT_MASK = 0x0000000000000FFFUL;

    private const byte NODE_MASK = 0x1F;
    private const long MAX_INCREMENT = 0xFFF;
    private static readonly TimeSpan _allowedFutureSkew = TimeSpan.FromMinutes(1);

    private static readonly byte _workerId;
    private static readonly byte _processId;
    private static readonly Lock _lock = new();
    private static long _lastTimestamp = -1;
    private static long _increment;

    static SnowflakeUtils()
    {
        _workerId = (byte)((uint)Environment.MachineName.GetHashCode(StringComparison.Ordinal) & NODE_MASK);
        _processId = (byte)(Environment.ProcessId & NODE_MASK);
    }

    public static ulong Generate()
    {
        lock (_lock)
        {
            var timestamp = CurrentTimestamp();
            if (timestamp < 0)
            {
                throw new InvalidOperationException("System clock is before the Celestials epoch (2015-01-01 UTC).");
            }

            if (timestamp < _lastTimestamp)
            {
                timestamp = _lastTimestamp;
            }

            if (timestamp == _lastTimestamp)
            {
                _increment = (_increment + 1) & MAX_INCREMENT;
                if (_increment == 0)
                {
                    timestamp = WaitNextMillisecond(_lastTimestamp);
                }
            }
            else
            {
                _increment = 0;
            }

            _lastTimestamp = timestamp;

            return ((ulong)timestamp << TIMESTAMP_SHIFT)
                | ((ulong)_workerId << WORKER_ID_SHIFT)
                | ((ulong)_processId << PROCESS_ID_SHIFT)
                | (ulong)_increment;
        }
    }

    public static DateTimeOffset ExtractTimestamp(ulong snowflake)
    {
        var timestamp = ExtractTimestampPart(snowflake);
        return DateTimeOffset.FromUnixTimeMilliseconds(timestamp + EPOCH);
    }

    public static byte ExtractWorkerId(ulong snowflake)
    {
        return (byte)((snowflake & WORKER_MASK) >> WORKER_ID_SHIFT);
    }

    public static byte ExtractProcessId(ulong snowflake)
    {
        return (byte)((snowflake & PROCESS_MASK) >> PROCESS_ID_SHIFT);
    }

    public static ushort ExtractIncrement(ulong snowflake)
    {
        return (ushort)(snowflake & INCREMENT_MASK);
    }

    public static bool IsValid(ulong snowflake)
    {
        if (snowflake is 0UL)
        {
            return false;
        }

        var unixMilliseconds = ExtractTimestampPart(snowflake) + EPOCH;

        if (unixMilliseconds < EPOCH)
        {
            return false;
        }

        var maxAcceptedTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + (long)_allowedFutureSkew.TotalMilliseconds;
        return unixMilliseconds <= maxAcceptedTimestamp;
    }

    private static long ExtractTimestampPart(ulong snowflake)
    {
        return (long)((snowflake & TIMESTAMP_MASK) >> TIMESTAMP_SHIFT);
    }

    private static long CurrentTimestamp()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - EPOCH;
    }

    private static long WaitNextMillisecond(long lastTimestamp)
    {
        var spinner = new SpinWait();
        long timestamp;

        do
        {
            timestamp = CurrentTimestamp();
            if (timestamp <= lastTimestamp)
            {
                spinner.SpinOnce();
            }
        } while (timestamp <= lastTimestamp);

        return timestamp;
    }
}
