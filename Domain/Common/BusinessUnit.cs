namespace FarmWebAPI.Domain.Common
{
	public class BusinessUnit : AuditableEntity
	{
		public int ParentBusinessUnitId { get; set; }
		public BusinessUnit ParentBusinessUnit { get; set; }
		public string PhoneNumber { get; set; } = string.Empty;
		public string EmailAddress { get; set; } = string.Empty;
		public DateTime StartDate { get; set; } = DateTime.UtcNow;
		public bool IsProfitCenter { get; set; }
		public decimal AnnualBudget { get; set; }
	}
}
