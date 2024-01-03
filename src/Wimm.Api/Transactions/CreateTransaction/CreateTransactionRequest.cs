namespace Wimm.Api.Transactions.CreateTransaction;

/// <summary>
/// A request to create a new transaction
/// </summary>
/// <param name="CategoryId">Unique identifier of the category</param>
public sealed record CreateTransactionRequest(Guid CategoryId);