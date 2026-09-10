using FarmWebAPI.Models.Companies;
using Microsoft.AspNetCore.Mvc;
using FarmWebAPI.AppDatabase;
using Microsoft.EntityFrameworkCore;
using FarmWebAPI.Models;
using FarmWebAPI.Domain.Common;
using FarmWebAPI.Domain.Farmer;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Azure.Core;


namespace FarmWebAPI.Controllers.Common
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompaniesController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public CompaniesController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/GetCompanies
		[HttpGet]
		public async Task<ActionResult<PagedCompanyResponse>> GetCompanies(
			[FromQuery] int page = 1,
			[FromQuery] int pageSize = 20,
			[FromQuery] string? search = null,
			[FromQuery] bool? isActive = null)
		{
			var query = _context.Companies.Where(c => !c.IsDeleted);
			if (isActive.HasValue)
			{
				query = query.Where(c => c.IsActive == isActive.Value);
			}
			if (!string.IsNullOrEmpty(search))
				query = query.Where(u => u.Name!.Contains(search) ||
				u.Code!.Contains(search) || u.EmailAddress.Contains(search) || u.RegistrationNumber.Contains(search));
			var totalCount = await query.CountAsync();
			var companies = await query
					.OrderBy(c => c.Name)
					.Skip((page - 1) * pageSize)
					.Take(pageSize)
					.Select(c => MapToResponse(c))
					.ToListAsync();


			return Ok(new PagedCompanyResponse
			{
				Companies = companies,
				TotalCount = totalCount,
				Page = page,
				PageSize = pageSize
			});

		}

		// GET: api/GetCompany/5
		[HttpGet("{id}")]
		public async Task<ActionResult<CompanyDetailResponse>> GetCompany(int id)
		{
			var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
			if (company is null)
				return NotFound(new { message = $"Company {id} was not found." });

			var contacts = await GetContactsAsync(id);
			var bankAccounts = await GetBankAccountsAsync(id);
			var documents = await GetDocumentsAsync(id);
			var holidays = await GetHolidaysAsync(id);

			var response = MapToDetailResponse(company);
			response.Contacts = contacts;
			response.BankAccounts = bankAccounts;
			response.Documents = documents;
			response.Holidays = holidays;

			return Ok(response);
		}

		// POST: api/companies
		[HttpPost]
		public async Task<ActionResult<CompanyResponse>> CreateCompany([FromBody] CreateCompanyRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var codeExists = await _context.Companies.AnyAsync(c => c.Code == request.Code && !c.IsDeleted);
			if (codeExists)
				return Conflict(new { message = $"Company code '{request.Code}' is already in use." });

			var company = new Company
			{
				Code = request.Code,
				Name = request.Name,
				Description = request.Description ?? string.Empty,
				RegistrationNumber = request.RegistrationNumber ?? string.Empty,
				TaxNumber = request.TaxNumber ?? string.Empty,
				PhoneNumber = request.PhoneNumber,
				AlternatePhoneNumber = request.AlternatePhoneNumber ?? string.Empty,
				EmailAddress = request.EmailAddress,
				Website = request.Website ?? string.Empty,
				Address = request.Address ?? string.Empty,
				PostalCode = request.PostalCode ?? string.Empty,
				CountryId = request.CountryId,
				CurrencyCode = request.CurrencyCode,
				TimeZone = request.TimeZone,
				FinancialYearStartMonth = request.FinancialYearStartMonth,
				Notes = request.Notes ?? string.Empty,
				IsActive = true,
				IsDeleted = false,
				CreatedOn = DateTime.UtcNow
			};
			_context.Companies.Add(company);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, MapToResponse(company));


		}

		// PUT: api/companies/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<ActionResult<CompanyResponse>> UpdateCompany(int id, [FromBody] UpdateCompanyRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
			if (company is null)
				return NotFound(new { message = $"Company {id} was not found." });

			var codeExists = await _context.Companies.AnyAsync(c => c.Code == request.Code && c.Id != id && !c.IsDeleted);
			if (codeExists)
				return Conflict(new { message = $"Company code '{request.Code}' is already used by another company." });

			company.Code = request.Code;
			company.Name = request.Name;
			company.Description = request.Description ?? string.Empty;
			company.RegistrationNumber = request.RegistrationNumber ?? string.Empty;
			company.TaxNumber = request.TaxNumber ?? string.Empty;
			company.PhoneNumber = request.PhoneNumber;
			company.AlternatePhoneNumber = request.AlternatePhoneNumber ?? string.Empty;
			company.EmailAddress = request.EmailAddress;
			company.Website = request.Website ?? string.Empty;
			company.Address = request.Address ?? string.Empty;
			company.PostalCode = request.PostalCode ?? string.Empty;
			company.CountryId = request.CountryId;
			company.CurrencyCode = request.CurrencyCode;
			company.TimeZone = request.TimeZone;
			company.FinancialYearStartMonth = request.FinancialYearStartMonth;
			company.Notes = request.Notes ?? string.Empty;
			company.IsActive = request.IsActive;
			company.ModifiedOn = DateTime.UtcNow;

			await _context.SaveChangesAsync();


			return Ok(MapToResponse(company));
		}
		// DELETE: api/FarmerDocuments/5
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteCompany(int id)
		{
			var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

			if (company is null)
				return NotFound(new { message = $"Company {id} was not found." });

			company.IsDeleted = true;
			company.IsActive = false;
			company.DeletedOn = DateTime.UtcNow;

			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpPut("{id:int}/activate")]
		public async Task<IActionResult> Activate(int id)
		{
			var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
			if (company is null)
				return NotFound(new { message = $"Company {id} was not found." });

			company.IsActive = true;
			company.ModifiedOn = DateTime.UtcNow;
			await _context.SaveChangesAsync();

			return Ok(new { message = $"Company '{company.Name}' activated." });
		}

		[HttpPut("{id:int}/deactivate")]
		public async Task<IActionResult> Deactivate(int id)
		{
			var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
			if (company is null)
				return NotFound(new { message = $"Company {id} was not found." });

			company.IsActive = false;
			company.ModifiedOn = DateTime.UtcNow;
			await _context.SaveChangesAsync();

			return Ok(new { message = $"Company '{company.Name}' deactivated." });
		}

		[HttpGet("{id:int}/contacts")]
		public async Task<ActionResult<List<CompanyContactResponse>>> GetContacts(int id)
		{
			if (!await CompanyExistsAsync(id))
				return NotFound(new { message = $"Company {id} was not found." });

			return Ok(await GetContactsAsync(id));
		}

		[HttpPost("{id:int}/contacts")]
		public async Task<ActionResult<CompanyContactResponse>> AddContact(int id, [FromBody] CreateCompanyContactRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!await CompanyExistsAsync(id))
				return NotFound(new { message = $"Company {id} was not found." });

			if (request.IsPrimaryContact)
				await ClearPrimaryContactAsync(id);

			var contact = new CompanyContact
			{
				CompanyId = id,
				ContactPerson = request.ContactPerson,
				Designation = request.Designation ?? string.Empty,
				Department = request.Department ?? string.Empty,
				EmailAddress = request.EmailAddress,
				PhoneNumber = request.PhoneNumber ?? string.Empty,
				MobileNumber = request.MobileNumber ?? string.Empty,
				IsPrimaryContact = request.IsPrimaryContact,
				IsActive = true,
				CreatedOn = DateTime.UtcNow,
			};

			_context.CompanyContacts.Add(contact);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetContacts), new { id }, MapContactToResponse(contact));
		}
		[HttpDelete("{id:int}/contacts/{contactId:int}")]
		public async Task<IActionResult> RemoveContact(int id, int contactId)
		{
			var contact = await _context.CompanyContacts.FirstOrDefaultAsync(c => c.Id == contactId && c.CompanyId == id && !c.IsDeleted);
			if (contact is null)
				return NotFound(new { message = $"Contact {contactId} was not found on company {id}." });

			contact.IsDeleted = true;
			contact.DeletedOn = DateTime.UtcNow;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpGet("{id:int}/bank-accounts")]
		public async Task<ActionResult<List<CompanyBankAccountResponse>>> GetBankAccounts(int id)
		{
			if (!await CompanyExistsAsync(id))
				return NotFound(new { message = $"Company {id} was not found." });

			return Ok(await GetBankAccountsAsync(id));
		}

		[HttpPost("{id:int}/bank-accounts")]
		public async Task<ActionResult<CompanyBankAccountResponse>> AddBankAccount(int id, [FromBody] CreateCompanyBankAccountRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!await CompanyExistsAsync(id))
				return NotFound(new { message = $"Company {id} was not found." });
			var duplicate = await _context.CompanyBankAccounts.AnyAsync(b => b.CompanyId == id && b.AccountNumber == request.AccountNumber && !b.IsDeleted);

			if (duplicate) return Conflict(new { message = $"Account number '{request.AccountNumber}' already exists for this company" });
			if (request.IsPrimaryAccount)
				await ClearPrimaryBankAccountAsync(id);

			var account = new CompanyBankAccount
			{
				CompanyId = id,
				BankName = request.BankName,
				BranchName = request.BranchName ?? string.Empty,
				AccountName = request.AccountName,
				AccountNumber = request.AccountNumber,
				IBAN = request.IBAN ?? string.Empty,
				SWIFTCode = request.SWIFTCode ?? string.Empty,
				CurrencyCode = request.CurrencyCode,
				IsPrimaryAccount = request.IsPrimaryAccount,
				IsActive = true,
				CreatedOn = DateTime.UtcNow
			};

			_context.CompanyBankAccounts.Add(account);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetBankAccounts), new { id }, MapBankAccountToResponse(account));
		}

		[HttpDelete("{id:int}/bank-accounts/{accountId:int}")]
		public async Task<IActionResult> RemoveBankAccount(int id, int accountId)
		{
			var account = await _context.CompanyBankAccounts.FirstOrDefaultAsync(c => c.Id == accountId && c.CompanyId == id && !c.IsDeleted);
			if (account is null)
				return NotFound(new { message = $"Bank account {accountId} was not found on company {id}." });
			if (account.IsPrimaryAccount)
				return BadRequest(new { message = "Cannot remove the primary bank account. Set another account as primary " });

			account.IsDeleted = true;
			account.DeletedOn = DateTime.UtcNow;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpGet("{id:int}/documents")]
		public async Task<ActionResult<List<CompanyDocumentResponse>>> GetDocuments(int id)
		{
			if (!await CompanyExistsAsync(id))
				return NotFound(new { message = $"Company {id} was not found." });

			return Ok(await GetDocumentsAsync(id));
		}

		[HttpPost("{id:int}/documents")]
		public async Task<ActionResult<CompanyDocumentResponse>> AddDocument(int id, [FromBody] CreateCompanyDocumentRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!await CompanyExistsAsync(id))
				return NotFound(new { message = $"Company {id} was not found." });
			var document = new CompanyDocument {

				CompanyId = id,
				DocumentName = request.DocumentName,
				DocumentType = request.DocumentType,
				DocumentNumber = request.DocumentNumber,
				IssueDate = request.IssueDate,
				ExpiryDate = request.ExpiryDate,
				IssuedBy = request.IssuedBy,
				FilePath = request.FilePath,
				FileName = request.FileName,
				FileType = request.FileType,
				FileSize = request.FileSize,
				Extension = request.Extension,
				IsActive = true,
				CreatedOn = DateTime.UtcNow
			};
			_context.CompanyDocuments.Add(document);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetDocuments), new { id }, MapDocumentToResponse(document));
		}

		[HttpDelete("{id:int}/documents/{documentId:int}")]
		public async Task<IActionResult> RemoveDocument(int id, int documentId)
		{
			var document = await _context.CompanyDocuments.FirstOrDefaultAsync(c => c.Id == documentId && c.CompanyId == id && !c.IsDeleted);
			if (document is null)
				return NotFound(new { message = $"Document {documentId} was not found on company {id}." });

			document.IsDeleted = true;
			document.DeletedOn = DateTime.UtcNow;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpGet("{id:int}/holidays")]
		public async Task<ActionResult<List<CompanyHolidayResponse>>> GetHolidays(int id)
		{
			if (!await CompanyExistsAsync(id))
				return NotFound(new { message = $"Company {id} was not found." });

			return Ok(await GetHolidaysAsync(id));
		}
		[HttpPost("{id:int}/holidays")]
		public async Task<ActionResult<CompanyHolidayResponse>> AddHoliday(int id, [FromBody] CreateCompanyHolidayRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!await CompanyExistsAsync(id))
				return NotFound(new { message = $"Company {id} was not found." });

			var duplicate = await _context.CompanyHolidays.AnyAsync(b => b.CompanyId == id && b.HolidayDate.Date == request.HolidayDate.Date && !b.IsDeleted);

			if (duplicate) return Conflict(new { message = $"A holiday already exists on '{request.HolidayDate:yyyy-MM-dd}' already exists for this company" });

			var holiday = new CompanyHoliday
			{
				CompanyId = id,
				HolidayName = request.HolidayName,
				HolidayDate = request.HolidayDate.Date,
				Remarks = request.Remarks ?? string.Empty,
				IsRecurring = request.IsRecurring,
				IsPaidHoliday = request.IsPaidHoliday,
				IsActive = true,
				CreatedOn = DateTime.UtcNow
			};

			_context.CompanyHolidays.Add(holiday);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetHolidays), new { id }, MapHolidayToResponse(holiday));
		}

		[HttpDelete("{id:int}/holidays/{holidayId:int}")]
		public async Task<IActionResult> RemoveHoliday(int id, int holidayId)
		{
			var holiday = await _context.CompanyHolidays.FirstOrDefaultAsync(c => c.Id == holidayId && c.CompanyId == id && !c.IsDeleted);
			if (holiday is null)
				return NotFound(new { message = $"Document {holidayId} was not found on company {id}." });

			holiday.IsDeleted = true;
			holiday.DeletedOn = DateTime.UtcNow;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		//Private helpers

		private Task<bool> CompanyExistsAsync(int id) => _context.Companies.AnyAsync(c => c.Id == id && !c.IsDeleted);

		private Task<List<CompanyContactResponse>> GetContactsAsync(int companyId) => _context.CompanyContacts
			.Where(c => c.CompanyId == companyId && !c.IsDeleted)
			.OrderByDescending(c => c.IsPrimaryContact)
			.ThenBy(c => c.ContactPerson)
			.Select(c => MapContactToResponse(c))
			.ToListAsync();

		private Task<List<CompanyBankAccountResponse>> GetBankAccountsAsync(int companyId) => _context.CompanyBankAccounts
			.Where(c => c.CompanyId == companyId && !c.IsDeleted)
			.OrderByDescending(c => c.IsPrimaryAccount)
			.ThenBy(c => c.BankName)
			.Select(c => MapBankAccountToResponse(c))
			.ToListAsync();

		private async Task ClearPrimaryBankAccountAsync(int companyId)
		{
			var existing = await _context.CompanyBankAccounts
				.Where(b => b.CompanyId == companyId && b.IsPrimaryAccount && !b.IsDeleted)
				.ToListAsync();
			existing.ForEach(b => b.IsPrimaryAccount = false);
		}

		private async Task ClearPrimaryContactAsync(int companyId)
		{
			var existing = await _context.CompanyContacts
				.Where(c => c.CompanyId == companyId &&
							c.IsPrimaryContact &&
							!c.IsDeleted)
				.ToListAsync();

			existing.ForEach(c => c.IsPrimaryContact = false);
		}

		private Task<List<CompanyDocumentResponse>> GetDocumentsAsync(int companyId) =>
			_context.CompanyDocuments
				.Where(d => d.CompanyId == companyId && !d.IsDeleted)
				.OrderByDescending(d => d.ExpiryDate)
				.ThenBy(d => d.DocumentName)
				.Select(d => MapDocumentToResponse(d))
				.ToListAsync();

		private Task<List<CompanyHolidayResponse>> GetHolidaysAsync(int companyId) =>
			_context.CompanyHolidays
				.Where(h => h.CompanyId == companyId && !h.IsDeleted)
				.OrderBy(h => h.HolidayDate)
				.Select(h => MapHolidayToResponse(h))
				.ToListAsync();
		
		// Mappers

		private static CompanyResponse MapToResponse(Company c) => new()
		{
			Id = c.Id,
			Code = c.Code,
			Name = c.Name,
			Description = c.Description,
			RegistrationNumber = c.RegistrationNumber,
			TaxNumber = c.TaxNumber,
			PhoneNumber = c.PhoneNumber,
			AlternatePhoneNumber = c.AlternatePhoneNumber,
			EmailAddress = c.EmailAddress,
			Website = c.Website,
			LogoUrl = c.LogoUrl,
			Address = c.Address,
			PostalCode = c.PostalCode,
			CountryId = c.CountryId,
			CurrencyCode = c.CurrencyCode,
			TimeZone = c.TimeZone,
			FinancialYearStartMonth = c.FinancialYearStartMonth,
			Notes = c.Notes,
			IsActive = c.IsActive,
			CreatedOn = c.CreatedOn,
			ModifiedOn = c.ModifiedOn
		};

		private static CompanyContactResponse MapContactToResponse(CompanyContact c) => new()
		{
			Id = c.Id,
			CompanyId = c.CompanyId,
			ContactPerson = c.ContactPerson,
			Designation = c.Designation,
			Department = c.Department,
			EmailAddress = c.EmailAddress,
			PhoneNumber = c.PhoneNumber,
			MobileNumber = c.MobileNumber,
			IsPrimaryContact = c.IsPrimaryContact
		};

		private static CompanyBankAccountResponse MapBankAccountToResponse(CompanyBankAccount b) => new()
		{
			Id = b.Id,
			CompanyId = b.CompanyId,
			BankName = b.BankName,
			BranchName = b.BranchName,
			AccountName = b.AccountName,
			AccountNumber = b.AccountNumber,
			IBAN = b.IBAN,
			SWIFTCode = b.SWIFTCode,
			CurrencyCode = b.CurrencyCode,
			IsPrimaryAccount = b.IsPrimaryAccount
		};

		private static CompanyDocumentResponse MapDocumentToResponse(CompanyDocument d) => new()
		{
			Id = d.Id,
			CompanyId = d.CompanyId,
			DocumentName = d.DocumentName,
			DocumentType = d.DocumentType,
			DocumentNumber = d.DocumentNumber,
			IssueDate = d.IssueDate,
			ExpiryDate = d.ExpiryDate,
			IssuedBy = d.IssuedBy,
			FileName = d.FileName,
			FileType = d.FileType,
			FileSize = d.FileSize,
			Extension = d.Extension
		};

		private static CompanyHolidayResponse MapHolidayToResponse(CompanyHoliday h) => new()
		{
			Id = h.Id,
			CompanyId = h.CompanyId,
			HolidayName = h.HolidayName,
			HolidayDate = h.HolidayDate,
			Remarks = h.Remarks,
			IsRecurring = h.IsRecurring,
			IsPaidHoliday = h.IsPaidHoliday,
			IsActive = h.IsActive
		};

		private static CompanyDetailResponse MapToDetailResponse(Company c) => new()
		{
			Id = c.Id,
			Code = c.Code,
			Name = c.Name,
			Description = c.Description,
			RegistrationNumber = c.RegistrationNumber,
			TaxNumber = c.TaxNumber,
			PhoneNumber = c.PhoneNumber,
			AlternatePhoneNumber = c.AlternatePhoneNumber,
			EmailAddress = c.EmailAddress,
			Website = c.Website,
			LogoUrl = c.LogoUrl,
			Address = c.Address,
			PostalCode = c.PostalCode,
			CountryId = c.CountryId,
			CurrencyCode = c.CurrencyCode,
			TimeZone = c.TimeZone,
			FinancialYearStartMonth = c.FinancialYearStartMonth,
			Notes = c.Notes,
			IsActive = c.IsActive,
			CreatedOn = c.CreatedOn,
			ModifiedOn = c.ModifiedOn,

			Contacts = new List<CompanyContactResponse>(),
			BankAccounts = new List<CompanyBankAccountResponse>(),
			Documents = new List<CompanyDocumentResponse>(),
			Holidays = new List<CompanyHolidayResponse>()
		};

	}
}
