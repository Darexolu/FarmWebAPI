using FarmWebAPI.Domain.Authentication;

namespace FarmWebAPI.Domain.Common
{
	public class Company : AuditableEntity
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
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
		public string? CreatedById { get; set; }
		public ApplicationUser? CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public string? ModifiedById { get; set; }
		public ApplicationUser ModifiedBy { get; set; }
		public DateTime? ModifiedOn { get; set; }
		public string? DeletedById { get; set; }
		public ApplicationUser DeletedBy { get; set; }
		public DateTime? DeletedOn { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }


	}
}
