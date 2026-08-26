using FarmWebAPI.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace FarmWebAPI.Domain.Authentication
{
	public class ApplicationRole : IdentityRole
	{
		public string Description { get; set; }
		public int CompanyId { get; set; }
		public bool IsActive { get; set; }
		public Company Company { get; set; }
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
