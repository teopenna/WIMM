namespace Wimm.Api.Common.Authentication;

internal static class AuthenticationModule
{
    internal static IServiceCollection AddWimmAuthentication(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.Configure<JwtTokenKeyConfig>(configuration.GetSection("Jwt"));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}