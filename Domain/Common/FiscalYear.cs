namespace FarmWebAPI.Domain.Common
{
	public class FiscalYear : AuditableEntity
	{
		public string Name { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public bool IsCurrentYear { get; set; }
		public bool IsClosed { get; set; }
	}
}
