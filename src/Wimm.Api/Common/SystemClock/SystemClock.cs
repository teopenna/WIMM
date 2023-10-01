namespace Wimm.Api.Common.SystemClock;

internal class SystemClock : ISystemClock
{
    public DateTimeOffset Now => DateTimeOffset.UtcNow;
}