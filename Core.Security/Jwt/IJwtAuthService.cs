using Core.Security.Jwt.Models;

namespace Core.Security.Jwt;

public interface IJwtAuthService
{
    Task<JwtTokenResponseModel> CreateToken(JwtTokenRequestModel model);
}
