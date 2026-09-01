using System.ComponentModel.DataAnnotations;

namespace FarmWebAPI.Models
{
	public class CreateUserRequest
	{
		[Required]
		[MaxLength(100)]
		public string FirstName { get; set; } = string.Empty;
		[Required]
		[MaxLength(100)]
		public string LastName { get; set; } = string.Empty;
		[Required]
		[EmailAddress]
		[MaxLength(256)]
		public string Email { get; set; } = string.Empty;
		[Required]
		[MaxLength(50)]
		public string UserName { get; set; } = string.Empty;
		[Required]
		[MaxLength(8)]
		public string Password { get; set; } = string.Empty;
		[Phone]
		[MaxLength(20)]
		public string? PhoneNumber { get; set; }
		
		[MaxLength(10)]
		public string? Gender { get; set; }

		public DateTime? DateOfBirth { get; set; }
		
		[MaxLength(200)]
		public string? Address { get; set; }

		[MaxLength(100)]
		public string? Country { get; set; }
		
		[MaxLength(50)]
		public string? NationalId { get; set; }

		[MaxLength(50)]
		public string? PassportNumber { get; set; }

		public int CompanyId { get; set; }

		public List<string> Roles { get; set; } = [];



	}



	public class UpdateUserRequest
	{
		[Required]
		[MaxLength(100)]
		public string FirstName { get; set; } = string.Empty;
		[Required]
		[MaxLength(100)]
		public string LastName { get; set; } = string.Empty;
		[Required]
		[EmailAddress]
		[MaxLength(256)]
		public string Email { get; set; } = string.Empty;
		[Required]
		[MaxLength(50)]
		public string UserName { get; set; } = string.Empty;
		[Required]
		[MaxLength(8)]
		public string Password { get; set; } = string.Empty;
		[Phone]
		[MaxLength(20)]
		public string? PhoneNumber { get; set; }

		[MaxLength(10)]
		public string? Gender { get; set; }

		public DateTime? DateOfBirth { get; set; }

		[MaxLength(200)]
		public string? Address { get; set; }

		[MaxLength(100)]
		public string? Country { get; set; }

		[MaxLength(50)]
		public string? NationalId { get; set; }

		[MaxLength(50)]
		public string? PassportNumber { get; set; }

		public int CompanyId { get; set; }

		public List<string> Roles { get; set; } = [];



	}
}
