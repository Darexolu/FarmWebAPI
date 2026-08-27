using FarmWebAPI.Domain.Common;

namespace FarmWebAPI.Domain.Farmer
{
	public class FarmerBankAccount : AuditableEntity
	{
		public int FarmerId { get; set; }
		public FarmerDetail Farmer { get; set; }
        public string BankName {  get; set; }
		public string BranchName { get; set; }
		public string AccountNumber { get; set; }
		public string AccountName { get; set; }
		public string SwiftCode { get; set; }
		public string IFSCCode { get; set; }
		public string AccountType { get; set; }
		public bool IsPrimaryAccount { get; set; }


	}
}
