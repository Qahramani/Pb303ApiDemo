using Core.Security.Jwt.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Security.Jwt;

public class JwtAuthManager : IJwtAuthService
{
    private readonly JwtSettings _jwtSettings;

    public JwtAuthManager(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<JwtTokenResponseModel> CreateToken(JwtTokenRequestModel model)
    {
        var jwtSecurityToken = createJwtToken(model);

        return new JwtTokenResponseModel
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
        };
    }

    private JwtSecurityToken createJwtToken(JwtTokenRequestModel model)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, model.Username),
            new Claim(JwtRegisteredClaimNames.Email, model.Email)
        };

        claims.AddRange(model.Roles.Select(x => new Claim(ClaimTypes.Role, x)));


        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }
}
