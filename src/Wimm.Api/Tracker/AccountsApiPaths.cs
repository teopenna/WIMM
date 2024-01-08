namespace Wimm.Api.Tracker;

internal static class AccountsApiPaths
{
    private const string AccountsRootApi = $"{ApiPaths.Root}/accounts";

    internal const string Create = AccountsRootApi;
    internal const string GetAll = AccountsRootApi;
    internal const string Get = $"{AccountsRootApi}/{{id}}";
}