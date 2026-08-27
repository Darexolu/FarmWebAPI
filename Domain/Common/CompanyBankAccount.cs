namespace FarmWebAPI.Domain.Common
{
	public class CompanyBankAccount : AuditableEntity
	{
		public string BankName { get; set; }
		public string BranchName { get; set; }
		public string AccountNumber { get; set;}
		public string AccountName { get; set; }
		public string IBAN { get; set; }
		public string SWIFTCode { get; set; }
		public string CurrencyCode { get; set; }
		public bool IsPrimaryAccount { get; set; }


	}
}
