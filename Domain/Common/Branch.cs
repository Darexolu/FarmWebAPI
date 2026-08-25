namespace FarmWebAPI.Domain.Common
{
	public class Branch : AuditableEntity
	{
		public int Id { get; set; }
		public string BranchCode { get; set; }
		public string BranchName { get; set; }

	}
}
