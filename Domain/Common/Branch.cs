namespace FarmWebAPI.Domain.Common
{
	public class Branch : AuditableEntity
	{
		public int? ParentBranchId { get; set; }
		public Branch? ParentBranch { get; set; }
		public string BranchCode { get; set; }
		public string BranchName { get; set; }
		public string Address { get; set; }
		public string PostCode { get; set; }
		public int CountryId { get; set; }	
		public DateTime OpeningDate { get; set; }


		


	}
}
