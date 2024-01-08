using Wimm.Api.Common.Enums;

namespace Wimm.Api.Tracker.CreateAccount;

/// <summary>
/// A request to create a new account
/// </summary>
/// <param name="Name">Name of the account</param>
/// <param name="AccountType">Type of the account</param>
/// <param name="Notes">Account notes</param>
internal sealed record CreateAccountRequest(string Name, AccountTypes AccountType, string Notes);