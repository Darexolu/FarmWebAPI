using System.ComponentModel.DataAnnotations;

namespace FarmWebAPI.Models
{
	public class UserResponse
	{
		public string Id { get; set; } = string.Empty;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string FullName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public string? PhoneNumber { get; set; }
		public string? Gender { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Address { get; set; }
		public string? Country { get; set; }
		public string? NationalId { get; set; }
		public string? PassportNumber { get; set; }
		public int CompanyId { get; set; }
		public bool IsActive { get; set; }
		public bool EmailConfirmed { get; set; }
		public bool LockoutEnabled { get; set; }
		public DateTimeOffset? LockoutEnd { get; set; }
		public List<string> Roles { get; set; } = [];
		public DateTime? CreatedOn { get; set; }
		public DateTime? ModifiedOn { get; set; }

	}
	public class PagedUserResponse
	{
		public List<UserResponse> Users { get; set; }
		public int TotalCount { get; set; }
		public int PageSize { get; set; }
		public int Page { get; set; }
		public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize); 

	}
}
