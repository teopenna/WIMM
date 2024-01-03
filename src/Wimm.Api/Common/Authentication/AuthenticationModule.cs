namespace Wimm.Api.Common.Authentication;

internal static class AuthenticationModule
{
    internal static IServiceCollection AddWimmAuthentication(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}