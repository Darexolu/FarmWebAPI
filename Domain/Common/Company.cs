namespace FarmWebAPI.Domain.Common
{
	public class Company : AuditableEntity
	{
		public string RegistrationNumber { get; set; } = string.Empty;
		public string TaxNumber { get; set;}= string.Empty;
		public string PhoneNumber {  get; set; }
		public string AlternatePhoneNumber { get; set; }
		public string EmailAddress { get; set; }
		public string Website { get; set; }
		public string LogoUrl { get; set; }
		public string Address { get; set; }
		public string PostalCode { get; set; }
		public int CountryId { get; set; }
		public string CurrencyCode { get; set; } = "USD";
		public string TimeZone { get; set; } = "UTC";
		public string FinancialYearStartMonth { get; set; } = "January";
		public string Notes { get; set; } 



	}
}
