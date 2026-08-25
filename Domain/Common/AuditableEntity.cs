using FarmWebAPI.Domain.Authentication;

namespace FarmWebAPI.Domain.Common
{
    public class AuditableEntity : BaseEntity
    {
		public string CreatedById { get; set; }
		public ApplicationUser CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public string? ModifiedById { get; set; }
		public ApplicationUser ModifiedBy { get; set; }
		public DateTime? ModifiedOn { get; set; }
		public string? DeletedById { get; set; }
		public ApplicationUser DeletedBy { get; set; }
		public DateTime? DeletedOn { get; set; }
	}
}
