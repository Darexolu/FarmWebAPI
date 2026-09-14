namespace FarmWebAPI.Models.Farmers
{
    public class FarmerResponse
    {
        public int Id { get; set; }
        public string FarmerNo { get; set; } = string.Empty;
        public string? NationalIdNo { get; set; }
        public string? PassportNo { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AlternatePhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public int FarmerTypeId { get; set; }
        public string? FarmerTypeName { get; set; }
        public int GenderId { get; set; }
        public string? GenderName { get; set; }
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

    public class FarmerDetailResponse : FarmerResponse
    {
        public List<FarmerContactResponse> Contacts { get; set; } = new();
        public List<FarmerBankAccountResponse> BankAccounts { get; set; } = new();
        public List<FarmerDocumentResponse> Documents { get; set; } = new();
    }

    public class PagedFarmerResponse
    {
        public List<FarmerResponse> Farmers { get; set; } = new();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }

    public class FarmerContactResponse
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public string? Relationship { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobileNumber { get; set; }
        public bool IsPrimaryContact { get; set; }
    }

    public class FarmerBankAccountResponse
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string? BranchName { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string? AccountName { get; set; }
        public string? SwiftCode { get; set; }
        public string? IFSCCode { get; set; }
        public string? AccountType { get; set; }
        public bool IsPrimaryAccount { get; set; }
    }

    public class FarmerDocumentResponse
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public string DocumentType { get; set; } = string.Empty;
        public string? DocumentNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public int AttachmentId { get; set; }
    }

    // Requests
    public class CreateFarmerRequest
    {
        public string FarmerNo { get; set; } = string.Empty;
        public string? NationalIdNo { get; set; }
        public string? PassportNo { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AlternatePhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public int FarmerTypeId { get; set; }
        public int GenderId { get; set; }
        public int CountryId { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool IsVerified { get; set; }
    }

    public class UpdateFarmerRequest : CreateFarmerRequest
    {
        public int Id { get; set; }
    }

    public class CreateFarmerContactRequest
    {
        public string ContactName { get; set; } = string.Empty;
        public string? Relationship { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobileNumber { get; set; }
        public bool IsPrimaryContact { get; set; }
    }

    public class CreateFarmerBankAccountRequest
    {
        public string BankName { get; set; } = string.Empty;
        public string? BranchName { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string? AccountName { get; set; }
        public string? SwiftCode { get; set; }
        public string? IFSCCode { get; set; }
        public string? AccountType { get; set; }
        public bool IsPrimaryAccount { get; set; }
    }

    public class CreateFarmerDocumentRequest
    {
        public string DocumentType { get; set; } = string.Empty;
        public string? DocumentNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int AttachmentId { get; set; }
    }
}
