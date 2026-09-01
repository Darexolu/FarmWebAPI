using System.ComponentModel.DataAnnotations;

namespace FarmWebAPI.Models.Users
{
	public class ChangePasswordRequest
	{
		[Required]
		public string CurrentPassword { get; set; } = string.Empty;
		[Required]
		[MaxLength(8)]
		public string NewPassword { get; set; } = string.Empty;
		[Required]
		[Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
		public string ConfirmNewPassword { get; set; } = string.Empty;


	}
	public class ResetPasswordRequest
	{
		[Required]
		[MaxLength(8)]
		public string NewPassword { get; set; } = string.Empty;

		[Required]
		[Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
		public string ConfirmNewPassword { get; set; } = string.Empty;

	}
	public class AssignRoleRequest
	{
		[Required]
		public string RoleName { get; set; } = string.Empty;


	}
}
