using Microsoft.AspNetCore.Identity;

namespace FarmWebAPI.Domain.Authentication
{
	public class ApplicationUser : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set;}
		public string FullName => $"{FirstName} {LastName}";
		public string? Address { get; set; }
		public string? Country { get; set; }
		public string? Gender { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? NationalId { get; set; }
		public string? PassportNumber { get; set; }
		public int CompanyId { get; set; }
		public string? CreatedById { get; set; }
		public ApplicationUser? CreatedBy { get; set; }
		public DateTime? CreatedOn { get; set; }
		public string? ModifiedById { get; set; }
		public ApplicationUser? ModifiedBy { get; set; }
		public DateTime? ModifiedOn { get; set; }
		public string? DeletedById { get; set; }
		public ApplicationUser? DeletedBy { get; set; }
		public DateTime? DeletedOn { get; set; }

	}
}
