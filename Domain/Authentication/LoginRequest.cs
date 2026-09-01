using System.ComponentModel.DataAnnotations;

namespace FarmWebAPI.Domain.Authentication
{
	public class LoginRequest
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
		
		[Required]
		public string Password { get; set; } = string.Empty;

		public string? DeviceInfo { get; set; }
	}

	public class RefreshTokenRequest
	{
		[Required]
		public string AccessToken { get; set; } = string.Empty;

		[Required]
		public string RefreshToken { get; set; } = string.Empty;

	}
	public class RevokeTokenRequest
	{
		[Required]
		public string RefreshToken { get; set; } = string.Empty;

	}
}
