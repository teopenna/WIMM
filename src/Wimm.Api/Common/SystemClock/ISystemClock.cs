namespace Wimm.Api.Common.SystemClock;

internal interface ISystemClock
{
    DateTimeOffset Now { get; }
}