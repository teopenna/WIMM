using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

using Wimm.Api.Common.SystemClock;

namespace Wimm.Api.Common.Authentication;

internal class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly ISystemClock _systemClock;

    public JwtTokenGenerator(ISystemClock systemClock)
    {
        _systemClock = systemClock;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("mysupersecret")),
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
            expires: _systemClock.Now.DateTime.AddHours(1),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}