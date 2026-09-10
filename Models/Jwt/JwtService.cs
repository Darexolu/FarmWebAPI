using FarmWebAPI.AppDatabase;
using FarmWebAPI.Domain.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FarmWebAPI.Models.Jwt
{
	public class JwtService : IJwtService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly JwtSettings _jwtSettings;
		public JwtService(UserManager<ApplicationUser> userManager, IOptions<JwtSettings> jwtSettings) {
			_userManager = userManager;
			_jwtSettings = jwtSettings.Value;
		}
		public async Task<string> GenerateAccessTokenAsync(ApplicationUser user)
		{
			var roles = await _userManager.GetRolesAsync(user);
			var claims = await _userManager.GetClaimsAsync(user);

			var tokenClaims = new List<Claim>
			{
				new(JwtRegisteredClaimNames.Sub, user.Id),
				new(JwtRegisteredClaimNames.Email, user.Email?? string.Empty),
				new(JwtRegisteredClaimNames.UniqueName, user.UserName?? string.Empty),
				new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(), ClaimValueTypes.Integer64),

				new("firstName", user.FirstName?? string.Empty),
				new("lastName", user.LastName?? string.Empty),
				new("companyId", user.CompanyId.ToString()),
			};

			tokenClaims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
			tokenClaims.AddRange(claims);

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer:   _jwtSettings.Issuer,
				audience: _jwtSettings.Audience,
				claims:     tokenClaims,
				notBefore:  DateTime.UtcNow,
				expires:    DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpiryMinutes),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public string GenerateRefreshToken()
		{
			var bytes = new byte[64];
			using var rng = RandomNumberGenerator.Create();	
			rng.GetBytes(bytes);
			return Convert.ToBase64String(bytes);	
		}

		public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
		{
			var validationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = false,
				ValidateIssuerSigningKey = true,
				ValidIssuer = _jwtSettings.Issuer,
				ValidAudience = _jwtSettings.Audience,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey))
		};

			var handler = new JwtSecurityTokenHandler();
			var principal = handler.ValidateToken(token, validationParameters, out var securityToken);
			if (securityToken is not JwtSecurityToken jwt || !jwt.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.OrdinalIgnoreCase)) return null;
			return principal;

			throw new NotImplementedException();
		}
	}
}
