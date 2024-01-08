namespace Wimm.Api.Common.Money;

internal sealed class Money
{
    public string Currency { get; set; } = default!;
    public decimal Amount { get; set; }
}