namespace Wimm.Api.Tracker.CreateTransaction;

/// <summary>
/// A request to create a new transaction
/// </summary>
/// <param name="AccountId">Unique identifier of the account</param>
/// <param name="CategoryId">Unique identifier of the category</param>
internal sealed record CreateTransactionRequest(Guid AccountId, Guid CategoryId);