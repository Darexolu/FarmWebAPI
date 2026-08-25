namespace FarmWebAPI.Domain.Common
{
	public class BusinessUnit : AuditableEntity
	{
		public int ParentBusinessUnitId { get; set; }
		public BusinessUnit ParentBusinessUnit { get; set; }
		public string PhoneNumber { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public DateTime StartDate { get; set; } = DateTime.UtcNow;
		public bool IsProfitCenter { get; set; }
	}
}
