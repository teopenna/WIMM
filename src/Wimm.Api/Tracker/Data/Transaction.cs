using Wimm.Api.Common.Money;

namespace Wimm.Api.Tracker.Data;

internal sealed class Transaction
{
    public Guid Id { get; init; }
    public Guid AccountId { get; init; }
    public Guid CategoryId { get; init; }
    public Money Amount { get; init; }
    public string Notes { get; init; }

    private Transaction(Guid id, Guid accountId, Guid categoryId, Money amount, string notes)
    {
        Id = id;
        AccountId = accountId;
        CategoryId = categoryId;
        Amount = amount;
        Notes = notes;
    }

    public static Transaction Create(Guid accountId, Guid categoryId, Money amount, string notes)
    {
        return new(Guid.NewGuid(), accountId, categoryId, amount, notes);
    }
}