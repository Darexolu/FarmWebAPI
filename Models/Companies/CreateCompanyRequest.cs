using System.ComponentModel.DataAnnotations;

namespace FarmWebAPI.Models.Companies
{
	public class CreateCompanyRequest
	{
		[Required,MaxLength(50)]
		public string Code { get; set; } = string.Empty;

		[Required, MaxLength(200)]
		public string Name { get; set; } = string.Empty;

		[Required, MaxLength(500)]
		public string? Description { get; set; }

		[MaxLength(100)]
		public string? RegistrationNumber { get; set; }

		[MaxLength(100)]
		public string? TaxNumber { get; set; }
		[Required, Phone, MaxLength(20)]
		public string PhoneNumber { get; set; } = string.Empty;
		[Phone, MaxLength(20)]
		public string? AlternatePhoneNumber { get; set; }
		[Required, EmailAddress, MaxLength(20)]
		public string EmailAddress { get; set; } = string.Empty;

		[Url, MaxLength(256)]
		public string? Website { get; set; }
		[MaxLength(500)]
		public string? Address { get; set; }
		[MaxLength(20)]
		public string? PostalCode { get; set; }
		[Required]
		public int CountryId { get; set; }
		[MaxLength(10)]
		public string CurrencyCode { get; set; } = "USD";
		[MaxLength(100)]
		public string TimeZone { get; set; } = "UTC";
		[MaxLength(20)]
		public string FinancialYearStartMonth { get; set; } = "January";
		[MaxLength(1000)]
		public string? Notes { get; set; } 





	}

	public class UpdateCompanyRequest
	{
		[Required, MaxLength(50)]
		public string Code { get; set; } = string.Empty;

		[Required, MaxLength(200)]
		public string Name { get; set; } = string.Empty;

		[Required, MaxLength(500)]
		public string? Description { get; set; }

		[MaxLength(100)]
		public string? RegistrationNumber { get; set; }

		[MaxLength(100)]
		public string? TaxNumber { get; set; }
		[Required, Phone, MaxLength(20)]
		public string PhoneNumber { get; set; } = string.Empty;
		[Phone, MaxLength(20)]
		public string? AlternatePhoneNumber { get; set; }
		[Required, EmailAddress, MaxLength(20)]
		public string EmailAddress { get; set; } = string.Empty;

		[Url, MaxLength(256)]
		public string? Website { get; set; }
		[MaxLength(500)]
		public string? Address { get; set; }
		[MaxLength(20)]
		public string? PostalCode { get; set; }
		[Required]
		public int CountryId { get; set; }
		[MaxLength(10)]
		public string CurrencyCode { get; set; } = "USD";
		[MaxLength(100)]
		public string TimeZone { get; set; } = "UTC";
		[MaxLength(20)]
		public string FinancialYearStartMonth { get; set; } = "January";
		[MaxLength(1000)]
		public string? Notes { get; set; }
		public bool IsActive { get; set; } 


	}

	public class CreateCompanyContactRequest {

		public string ContactPerson { get; set; }
		public string Designation { get; set; }
		public string Department { get; set; }
		public string EmailAddress { get; set; }
		public string PhoneNumber { get; set; }
		public string MobileNumber { get; set; }
		public bool IsPrimaryContact { get; set; }
	}

	public class CreateCompanyBankAccountRequest {
		public string BankName { get; set; }
		public string BranchName { get; set; }
		public string AccountNumber { get; set; }
		public string AccountName { get; set; }
		public string IBAN { get; set; }
		public string SWIFTCode { get; set; }
		public string CurrencyCode { get; set; }
		public bool IsPrimaryAccount { get; set; }
	}

	public class CreateCompanyDocumentRequest {

		public string DocumentName { get; set; }
		public string DocumentType { get; set; }
		public string DocumentNumber { get; set; }
		public DateTime? IssueDate { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public string IssuedBy { get; set; }
		public string FilePath { get; set; }
		public string FileName { get; set; }
		public string FileType { get; set; }
		public string FileSize { get; set; }
		public string Extension { get; set; }
		public string CheckSum { get; set; }
	}

	public class CreateCompanyHolidayRequest
	{
		public string HolidayName { get; set; }
		public DateTime HolidayDate { get; set; }
		public string Remarks { get; set; }
		public bool IsRecurring { get; set; }
		public bool IsPaidHoliday { get; set; }

	}
}

