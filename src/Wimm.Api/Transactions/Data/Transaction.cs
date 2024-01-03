namespace Wimm.Api.Transactions.Data;

internal sealed class Transaction
{
    public Guid Id { get; init; }
    public Guid CategoryId { get; init; }

    private Transaction(Guid id, Guid categoryId)
    {
        Id = id;
        CategoryId = categoryId;
    }

    public static Transaction Create(Guid categoryId)
    {
        return new(Guid.NewGuid(), categoryId);
    }
}