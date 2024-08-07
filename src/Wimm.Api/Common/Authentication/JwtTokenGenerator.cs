using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Wimm.Api.Common.SystemClock;

namespace Wimm.Api.Common.Authentication;

internal class JwtTokenGenerator(
    ISystemClock systemClock,
    IOptions<JwtTokenKeyConfig> jwtConfigOptions) : IJwtTokenGenerator
{
    private readonly JwtTokenKeyConfig _jwtConfig = jwtConfigOptions.Value;
    
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtConfig.Key)),
            SecurityAlgorithms.HmacSha256);
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("TenantId", string.Empty)
        };

        var securityToken = new JwtSecurityToken(
            issuer: "Wimm",
            expires: systemClock.Now.DateTime.AddHours(1),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}