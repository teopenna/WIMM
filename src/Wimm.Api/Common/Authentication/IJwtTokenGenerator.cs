namespace Wimm.Api.Common.Authentication;

internal interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string firstName, string lastName);
}