namespace FarmWebAPI.Models.Companies
{
	public class CompanyResponse
	{
		public int Id { get; set; }
		public string Code { get; set; } = string.Empty;
		public string Name { get; set; }= string.Empty;
		public string? Description { get; set; }
		public string? RegistrationNumber { get; set; }
		public string? TaxNumber { get; set; }
		public string PhoneNumber { get; set; } = string.Empty;
		public string? AlternatePhoneNumber { get; set; }
		public string EmailAddress { get; set; } = string.Empty;
		public string? Website { get; set; }
		public string? LogoUrl { get; set; }
		public string? Address { get; set;}
		public string? PostalCode { get; set; }
		public int CountryId { get; set; }
		public string CurrencyCode { get; set; } = string.Empty;
		public string TimeZone { get; set; }= string.Empty;
		public string FinancialYearStartMonth { get; set; } = string.Empty;
		public string? Notes { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? ModifiedOn { get; set; }

	}
	public class CompanyDetailResponse : CompanyResponse
	{
		public List<CompanyContactResponse> Contacts { get; set; } = [];
		public List<CompanyBankAccountResponse> BankAccounts { get; set; } = [];
		public List<CompanyDocumentResponse> Documents { get; set; } = [];
		public List<CompanyHolidayResponse> Holidays { get; set; } = [];

	}
	public class PagedCompanyResponse 
	{
		public List<CompanyResponse> Companies { get; set; } = [];
		public int TotalCount { get; set; }
		public int Page { get; set; }
		public int PageSize { get; set; }
		public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

	}
	//Contact
	public class CompanyContactResponse {

		public int Id { get; set; }
		public int CompanyId { get; set; }
		public string ContactPerson { get; set;} = string.Empty;
		public string? Designation { get; set;}
		public string? Department { get; set; }
		public string EmailAddress { get; set; } = string.Empty;
		public string? PhoneNumber { get; set;}
		public string? MobileNumber { get; set;}
		public bool IsPrimaryContact { get; set; }
	}

	// Bank Account
	public class CompanyBankAccountResponse {
	  public int Id { get; set; }
	  public int CompanyId { get; set; }
	  public string BankName { get; set; } = string.Empty;
	  public string? BranchName { get; set; }
	  public string AccountNumber { get; set; } = string.Empty;
	  public string? AccountName { get; set; } = string.Empty;
	  public string? IBAN { get; set; }
	  public string? SWIFTCode { get; set; }
	  public string CurrencyCode { get; set; } = string.Empty;
	  public bool IsPrimaryAccount { get; set; }
	}
	// Document 
	public class CompanyDocumentResponse
	{
		public int Id { get; set; }
		public int CompanyId { get; set; }
		public string DocumentName { get; set; } = string.Empty;
		public string DocumentType { get; set; } = string.Empty;
		public string? DocumentNumber { get; set; } 
		public DateTime? IssueDate { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public string? IssuedBy { get; set; }
		public string FileName { get; set; } = string.Empty;
		public string? FileType { get; set; }
		public string FileSize { get; set; }
		public string? Extension {  get; set; }
		public bool IsExpiringSoon =>ExpiryDate.HasValue && ExpiryDate.Value <= DateTime.UtcNow.AddDays(30) && ExpiryDate.Value >= DateTime.UtcNow;
		public bool IsExpired =>ExpiryDate.HasValue &&	ExpiryDate.Value < DateTime.UtcNow;
	}

	// Holiday
	public class CompanyHolidayResponse
	{
		public int Id { get; set; }
		public int CompanyId { get; set; }
		public string HolidayName { get; set; } = string.Empty;
		public DateTime? HolidayDate { get; set; }
		public string? Remarks { get; set; } 
		public bool IsRecurring { get; set; }
		public bool IsPaidHoliday { get; set; }
		public bool IsActive { get; set; }


	}
}
