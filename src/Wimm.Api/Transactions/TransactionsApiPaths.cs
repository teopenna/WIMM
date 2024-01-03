namespace Wimm.Api.Transactions;

internal static class TransactionsApiPaths
{
    private const string TransactionsRootApi = $"{ApiPaths.Root}/transactions";

    internal const string Create = TransactionsRootApi;
    internal const string GetAll = TransactionsRootApi;
    internal const string Get = $"{TransactionsRootApi}/{{id}}";
}