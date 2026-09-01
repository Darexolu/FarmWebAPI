using FarmWebAPI.Domain.Authentication;
using System.Security.Claims;

namespace FarmWebAPI.Models.Jwt
{
	public interface IJwtService
	{
		Task<string> GenerateAccessTokenAsync(ApplicationUser user);
		string GenerateRefreshToken();
		ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
	}
}
