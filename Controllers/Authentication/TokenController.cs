using Azure.Core;
using Azure.Identity;
using FarmWebAPI.AppDatabase;
using FarmWebAPI.Domain.Authentication;
using FarmWebAPI.Models.Jwt;
using FarmWebAPI.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NuGet.Protocol.Plugins;
using System;
using System.Security.Claims;

namespace FarmWebAPI.Controllers.Authentication
{
	[Route("api/[controller]")]
	[ApiController]
	public class TokenController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ApplicationDbContext _context;
		private readonly IJwtService _jwtService;
		private readonly JwtSettings _jwtSettings;

		public TokenController(
		UserManager<ApplicationUser> userManager,
		SignInManager<ApplicationUser> signInManager, IJwtService jwtService, ApplicationDbContext context,IOptions<JwtSettings> jwtSettings)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_jwtService = jwtService;
			_context = context;
			_jwtSettings = jwtSettings.Value;
		}

		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<ActionResult<TokenResponse>> Login([FromBody] LoginRequest request)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var user = await _userManager.FindByEmailAsync(request.Email);

			if (user is null || user.DeletedOn != null)
			{
				await RecordLoginHistoryAsync(null, request, success: false, reason: "User not found");
				return Unauthorized(new { message = "Invalid email or password." });
			}
			if(await _userManager.IsLockedOutAsync(user))
			{
				await RecordLoginHistoryAsync(null, request, success: false, reason: "Account locked");
				return Unauthorized(new { message = "Account is locked. Try again later." });
			}
			var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
			if (!passwordValid)
			{
				await _userManager.AccessFailedAsync(user);
				await RecordLoginHistoryAsync(user, request, success: false, reason: "Invalid password");
				return Unauthorized(new {message = "Invalid email or password"});
			}

			await _userManager.ResetAccessFailedCountAsync(user);
			var tokenResponse = await IssueTokenAsync(user);
			await RecordLoginHistoryAsync(user,request,success: true, reason:string.Empty);
			return Ok(tokenResponse);
		}

		[HttpPost("refresh")]
		[AllowAnonymous]
		public async Task<ActionResult<TokenResponse>> Refresh([FromBody] RefreshTokenRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var principal = _jwtService.GetPrincipalFromExpiredToken(request.AccessToken);
			if (principal is null)
				return Unauthorized(new {message = "Invalid access token."});
			var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? principal.FindFirstValue("sub");

			if(string.IsNullOrEmpty(userId))
				return Unauthorized(new { message = "Invalid token claims." });

			var storedToken = await _context.RefreshTokens.Include(rt => rt.User).FirstOrDefaultAsync(rt => rt.Token == request.RefreshToken
			&& rt.UserId == userId);
			if(storedToken is null|| storedToken.IsRevoked || storedToken.IsExpired)
				return Unauthorized(new {message = "Isvalid or expired refresh token."});

			if(storedToken.ExpiryDate < DateTime.UtcNow)
			{
				storedToken.IsExpired = true;
				await _context.SaveChangesAsync();
				return Unauthorized(new {message="Refresh token has expired. Please log in again" });
			}

			var user = storedToken.User;
			if (user.DeletedOn != null || await _userManager.IsLockedOutAsync(user))
				return Unauthorized(new { message = "Account is inactive or locked" });

			//Rotate the refresh token
			storedToken.IsRevoked = true;
			storedToken.RevokedOn = DateTime.UtcNow;

			var tokenResponse = await IssueTokenAsync(user);
			storedToken.ReplacedByToken = tokenResponse.RefreshToken;

			await _context.SaveChangesAsync();
			return Ok(tokenResponse);

		}

		[HttpPost("revoke")]
		[Authorize]
		public async Task<IActionResult> Revoke([FromBody] RefreshTokenRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub");
			var storedToken = await _context.RefreshTokens.Include(rt => rt.User).FirstOrDefaultAsync(rt => rt.Token == request.RefreshToken
			&& rt.UserId == userId);

			if (storedToken is null)
				return NotFound(new { message = "Refresh token not found." });

			if (storedToken.IsRevoked)
				return BadRequest(new { message = "Token is already revoked." });
			storedToken.IsRevoked = true;
			storedToken.RevokedOn = DateTime.UtcNow;
			await _context.SaveChangesAsync();

			return Ok(new {message = "Token revoked successfully"});

		}
		//rovokes token for current user
		[HttpPost("revoke-all")]
		[Authorize]
		public async Task<IActionResult> RevokeAll()
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub");
			var activeTokens = await _context.RefreshTokens.Where(rt => rt.UserId == userId && !rt.IsRevoked).ToListAsync();
			if (activeTokens.Count == 0)
				return Ok(new { message = "No active tokens found" });
			foreach( var token in activeTokens)
			{
				token.IsRevoked = true;
				token.RevokedOn = DateTime.UtcNow; 
			}

			await _context.SaveChangesAsync();

			return Ok(new { message = $"{activeTokens.Count} token(s) revoked successfully" });

		}


		//private helpers

		private async Task<TokenResponse> IssueTokenAsync(ApplicationUser user)
		{
			var accessToken = await _jwtService.GenerateAccessTokenAsync(user);
			var rawRefreshToken = _jwtService.GenerateRefreshToken();
			var accessExpiry = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpiryMinutes);
			var refreshExpiry = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays);
			_context.RefreshTokens.Add(new RefreshToken
			{
				Token = rawRefreshToken,
				UserId = user.Id,
				CreatedOn = DateTime.UtcNow,
				ExpiryDate = refreshExpiry,
				IsExpired = false,
				IsRevoked = false
			});
			await _context.SaveChangesAsync();

			var roles = await _userManager.GetRolesAsync(user);
			return new TokenResponse
			{
				AccessToken = accessToken,
				RefreshToken = rawRefreshToken,
				AccessTokenExpiry = accessExpiry,
				RefreshTokenExpiry = refreshExpiry,
				User = new UserTokenInfo
				{
					Id = user.Id,
					FullName = user.FullName,
					Email = user.Email ?? string.Empty,
					UserName = user.UserName ?? string.Empty,
					CompanyId = user.CompanyId,
					Roles = roles,

				}
			};
		}
		private async Task RecordLoginHistoryAsync(ApplicationUser? user, LoginRequest request, bool success, string reason)
		{
			var ua = HttpContext.Request.Headers.UserAgent.ToString();
			_context.LoginHistories.Add(new LoginHistory
			{
               UserId = user?.Id ?? string.Empty,
			   LoginTime = DateTime.UtcNow,
			   IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString()?? string.Empty,
			   Browser = ua.Length > 200 ? ua[..200]: ua,
			   Device = request.DeviceInfo ?? string.Empty,
			   LoginSuccessful = success,
			   FailureReason = reason
			});

			await _context.SaveChangesAsync();
		}
	}
}
