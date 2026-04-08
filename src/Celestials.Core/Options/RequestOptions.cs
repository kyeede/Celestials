namespace Celestials.Core.Options;

public sealed class RequestOptions
{
    public static RequestOptions Default => new();

    public int? Timeout { get; set; }
    public CancellationToken CancellationToken { get; set; }
    public RetryMode? RetryMode { get; set; }
    public bool HeaderOnly { get; internal set; }
    public string? AuditLogReason { get; set; }
    public bool? UseSystemClock { get; set; }
    public Func<IRateLimitInfo, Task>? RatelimitCallback { get; set; }

    internal bool IgnoreState { get; set; }
    internal IDictionary<string, IEnumerable<string>> RequestHeaders { get; }

    public RequestOptions()
    {
        RequestHeaders = new Dictionary<string, IEnumerable<string>>();
        CancellationToken = CancellationToken.None;
    }

    public RequestOptions Clone() => (RequestOptions)MemberwiseClone();

    internal static RequestOptions CreateOrClone(RequestOptions? options) =>
        options?.Clone() ?? new RequestOptions();

    internal void ExecuteRatelimitCallback(IRateLimitInfo info)
    {
        if (RatelimitCallback is null)
        {
            return;
        }

        _ = Task.Run(async () => await RatelimitCallback(info));
    }
}
