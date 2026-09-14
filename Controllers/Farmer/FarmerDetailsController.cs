using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmWebAPI.AppDatabase;
using FarmWebAPI.Domain.Farmer;
using FarmWebAPI.Models.Farmers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmWebAPI.Controllers.Farmer
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FarmerDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FarmerDetails
        [HttpGet]
        public async Task<ActionResult<PagedFarmerResponse>> GetFarmers(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20,
            [FromQuery] string? search = null,
            [FromQuery] bool? isActive = null)
        {
            var query = _context.FarmerDetails.Where(f => !f.IsDeleted);
            if (isActive.HasValue)
            {
                query = query.Where(f => f.IsActive == isActive.Value);
            }

            if (!string.IsNullOrEmpty(search))
                query = query.Where(f => f.FarmerNo.Contains(search) ||
                                         f.FirstName.Contains(search) ||
                                         f.LastName.Contains(search) ||
                                         f.NationalIdNo.Contains(search) ||
                                         f.PhoneNumber.Contains(search));

            var totalCount = await query.CountAsync();

            var farmers = await query
                .OrderBy(f => f.FirstName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(f => MapToResponse(f))
                .ToListAsync();

            return Ok(new PagedFarmerResponse
            {
                Farmers = farmers,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            });
        }

        // GET: api/FarmerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FarmerDetailResponse>> GetFarmer(int id)
        {
            var farmer = await _context.FarmerDetails.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (farmer is null)
                return NotFound(new { message = $"Farmer {id} was not found." });

            var contacts = await GetContactsAsync(id);
            var bankAccounts = await GetBankAccountsAsync(id);
            var documents = await GetDocumentsAsync(id);

            var response = MapToDetailResponse(farmer);
            response.Contacts = contacts;
            response.BankAccounts = bankAccounts;
            response.Documents = documents;

            return Ok(response);
        }

        // POST: api/FarmerDetails
        [HttpPost]
        public async Task<ActionResult<FarmerResponse>> CreateFarmer([FromBody] CreateFarmerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _context.FarmerDetails.AnyAsync(f => f.FarmerNo == request.FarmerNo && !f.IsDeleted);
            if (exists)
                return Conflict(new { message = $"Farmer number '{request.FarmerNo}' is already in use." });

            var farmer = new FarmerDetail
            {
                FarmerNo = request.FarmerNo,
                NationalIdNo = request.NationalIdNo ?? string.Empty,
                PassportNo = request.PassportNo,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName ?? string.Empty,
                LastName = request.LastName,
                Address = request.Address ?? string.Empty,
                PhoneNumber = request.PhoneNumber ?? string.Empty,
                AlternatePhoneNumber = request.AlternatePhoneNumber ?? string.Empty,
                EmailAddress = request.EmailAddress ?? string.Empty,
                FarmerTypeId = request.FarmerTypeId,
                GenderId = request.GenderId,
                CountryId = request.CountryId,
                UnitOfMeasurementId = request.UnitOfMeasurementId,
                RegistrationDate = request.RegistrationDate ?? DateTime.UtcNow,
                IsVerified = request.IsVerified,
                IsActive = true,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow
            };

            _context.FarmerDetails.Add(farmer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFarmer), new { id = farmer.Id }, MapToResponse(farmer));
        }

        // PUT: api/FarmerDetails/5
        [HttpPut("{id}")]
        public async Task<ActionResult<FarmerResponse>> UpdateFarmer(int id, [FromBody] UpdateFarmerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var farmer = await _context.FarmerDetails.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (farmer is null)
                return NotFound(new { message = $"Farmer {id} was not found." });

            var codeExists = await _context.FarmerDetails.AnyAsync(f => f.FarmerNo == request.FarmerNo && f.Id != id && !f.IsDeleted);
            if (codeExists)
                return Conflict(new { message = $"Farmer number '{request.FarmerNo}' is already used by another farmer." });

            farmer.FarmerNo = request.FarmerNo;
            farmer.NationalIdNo = request.NationalIdNo ?? string.Empty;
            farmer.PassportNo = request.PassportNo;
            farmer.FirstName = request.FirstName;
            farmer.MiddleName = request.MiddleName ?? string.Empty;
            farmer.LastName = request.LastName;
            farmer.Address = request.Address ?? string.Empty;
            farmer.PhoneNumber = request.PhoneNumber ?? string.Empty;
            farmer.AlternatePhoneNumber = request.AlternatePhoneNumber ?? string.Empty;
            farmer.EmailAddress = request.EmailAddress ?? string.Empty;
            farmer.FarmerTypeId = request.FarmerTypeId;
            farmer.GenderId = request.GenderId;
            farmer.CountryId = request.CountryId;
            farmer.UnitOfMeasurementId = request.UnitOfMeasurementId;
            farmer.IsVerified = request.IsVerified;
            farmer.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(MapToResponse(farmer));
        }

        // DELETE: api/FarmerDetails/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFarmer(int id)
        {
            var farmer = await _context.FarmerDetails.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (farmer is null)
                return NotFound(new { message = $"Farmer {id} was not found." });

            farmer.IsDeleted = true;
            farmer.IsActive = false;
            farmer.DeletedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id:int}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var farmer = await _context.FarmerDetails.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (farmer is null)
                return NotFound(new { message = $"Farmer {id} was not found." });

            farmer.IsActive = true;
            farmer.ModifiedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Farmer '{farmer.FirstName} {farmer.LastName}' activated." });
        }

        [HttpPut("{id:int}/deactivate")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var farmer = await _context.FarmerDetails.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (farmer is null)
                return NotFound(new { message = $"Farmer {id} was not found." });

            farmer.IsActive = false;
            farmer.ModifiedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Farmer '{farmer.FirstName} {farmer.LastName}' deactivated." });
        }

        [HttpGet("{id:int}/contacts")]
        public async Task<ActionResult<List<FarmerContactResponse>>> GetContacts(int id)
        {
            if (!await FarmerExistsAsync(id))
                return NotFound(new { message = $"Farmer {id} was not found." });

            return Ok(await GetContactsAsync(id));
        }

        [HttpPost("{id:int}/contacts")]
        public async Task<ActionResult<FarmerContactResponse>> AddContact(int id, [FromBody] CreateFarmerContactRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await FarmerExistsAsync(id))
                return NotFound(new { message = $"Farmer {id} was not found." });

            if (request.IsPrimaryContact)
                await ClearPrimaryContactAsync(id);

            var contact = new FarmerContact
            {
                FarmerId = id,
                ContactName = request.ContactName,
                Relationship = request.Relationship ?? string.Empty,
                EmailAddress = request.EmailAddress ?? string.Empty,
                PhoneNumber = request.PhoneNumber ?? string.Empty,
                MobileNumber = request.MobileNumber ?? string.Empty,
                IsPrimaryContact = request.IsPrimaryContact,
                IsActive = true,
                CreatedOn = DateTime.UtcNow
            };

            _context.FarmerContacts.Add(contact);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContacts), new { id }, MapContactToResponse(contact));
        }

        [HttpDelete("{id:int}/contacts/{contactId:int}")]
        public async Task<IActionResult> RemoveContact(int id, int contactId)
        {
            var contact = await _context.FarmerContacts.FirstOrDefaultAsync(c => c.Id == contactId && c.FarmerId == id && !c.IsDeleted);
            if (contact is null)
                return NotFound(new { message = $"Contact {contactId} was not found for farmer {id}." });

            contact.IsDeleted = true;
            contact.DeletedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id:int}/bank-accounts")]
        public async Task<ActionResult<List<FarmerBankAccountResponse>>> GetBankAccounts(int id)
        {
            if (!await FarmerExistsAsync(id))
                return NotFound(new { message = $"Farmer {id} was not found." });

            return Ok(await GetBankAccountsAsync(id));
        }

        [HttpPost("{id:int}/bank-accounts")]
        public async Task<ActionResult<FarmerBankAccountResponse>> AddBankAccount(int id, [FromBody] CreateFarmerBankAccountRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await FarmerExistsAsync(id))
                return NotFound(new { message = $"Farmer {id} was not found." });

            var duplicate = await _context.FarmerBankAccounts.AnyAsync(b => b.FarmerId == id && b.AccountNumber == request.AccountNumber && !b.IsDeleted);
            if (duplicate) return Conflict(new { message = $"Account number '{request.AccountNumber}' already exists for this farmer" });
            if (request.IsPrimaryAccount)
                await ClearPrimaryBankAccountAsync(id);

            var account = new FarmerBankAccount
            {
                FarmerId = id,
                BankName = request.BankName,
                BranchName = request.BranchName ?? string.Empty,
                AccountName = request.AccountName ?? string.Empty,
                AccountNumber = request.AccountNumber,
                SwiftCode = request.SwiftCode ?? string.Empty,
                IFSCCode = request.IFSCCode ?? string.Empty,
                AccountType = request.AccountType ?? string.Empty,
                IsPrimaryAccount = request.IsPrimaryAccount,
                IsActive = true,
                CreatedOn = DateTime.UtcNow
            };

            _context.FarmerBankAccounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBankAccounts), new { id }, MapBankAccountToResponse(account));
        }

        [HttpDelete("{id:int}/bank-accounts/{accountId:int}")]
        public async Task<IActionResult> RemoveBankAccount(int id, int accountId)
        {
            var account = await _context.FarmerBankAccounts.FirstOrDefaultAsync(c => c.Id == accountId && c.FarmerId == id && !c.IsDeleted);
            if (account is null)
                return NotFound(new { message = $"Bank account {accountId} was not found for farmer {id}." });
            if (account.IsPrimaryAccount)
                return BadRequest(new { message = "Cannot remove the primary bank account. Set another account as primary " });

            account.IsDeleted = true;
            account.DeletedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id:int}/documents")]
        public async Task<ActionResult<List<FarmerDocumentResponse>>> GetDocuments(int id)
        {
            if (!await FarmerExistsAsync(id))
                return NotFound(new { message = $"Farmer {id} was not found." });

            return Ok(await GetDocumentsAsync(id));
        }

        [HttpPost("{id:int}/documents")]
        public async Task<ActionResult<FarmerDocumentResponse>> AddDocument(int id, [FromBody] CreateFarmerDocumentRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await FarmerExistsAsync(id))
                return NotFound(new { message = $"Farmer {id} was not found." });

            var document = new FarmerDocument
            {
                FarmerId = id,
                DocumentType = request.DocumentType,
                DocumentNumber = request.DocumentNumber ?? string.Empty,
                IssueDate = request.IssueDate,
                ExpiryDate = request.ExpiryDate,
                IsActive = true,
                AttachmentId = request.AttachmentId,
                CreatedOn = DateTime.UtcNow
            };

            _context.FarmerDocuments.Add(document);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDocuments), new { id }, MapDocumentToResponse(document));
        }

        [HttpDelete("{id:int}/documents/{documentId:int}")]
        public async Task<IActionResult> RemoveDocument(int id, int documentId)
        {
            var document = await _context.FarmerDocuments.FirstOrDefaultAsync(c => c.Id == documentId && c.FarmerId == id && !c.IsDeleted);
            if (document is null)
                return NotFound(new { message = $"Document {documentId} was not found for farmer {id}." });

            document.IsDeleted = true;
            document.DeletedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Private helpers
        private Task<bool> FarmerExistsAsync(int id) => _context.FarmerDetails.AnyAsync(f => f.Id == id && !f.IsDeleted);

        private Task<List<FarmerContactResponse>> GetContactsAsync(int farmerId) => _context.FarmerContacts
            .Where(c => c.FarmerId == farmerId && !c.IsDeleted)
            .OrderByDescending(c => c.IsPrimaryContact)
            .ThenBy(c => c.ContactName)
            .Select(c => MapContactToResponse(c))
            .ToListAsync();

        private Task<List<FarmerBankAccountResponse>> GetBankAccountsAsync(int farmerId) => _context.FarmerBankAccounts
            .Where(b => b.FarmerId == farmerId && !b.IsDeleted)
            .OrderByDescending(b => b.IsPrimaryAccount)
            .ThenBy(b => b.BankName)
            .Select(b => MapBankAccountToResponse(b))
            .ToListAsync();

        private async Task ClearPrimaryBankAccountAsync(int farmerId)
        {
            var existing = await _context.FarmerBankAccounts
                .Where(b => b.FarmerId == farmerId && b.IsPrimaryAccount && !b.IsDeleted)
                .ToListAsync();
            existing.ForEach(b => b.IsPrimaryAccount = false);
        }

        private async Task ClearPrimaryContactAsync(int farmerId)
        {
            var existing = await _context.FarmerContacts
                .Where(c => c.FarmerId == farmerId && c.IsPrimaryContact && !c.IsDeleted)
                .ToListAsync();
            existing.ForEach(c => c.IsPrimaryContact = false);
        }

        private Task<List<FarmerDocumentResponse>> GetDocumentsAsync(int farmerId) => _context.FarmerDocuments
            .Where(d => d.FarmerId == farmerId && !d.IsDeleted)
            .OrderByDescending(d => d.ExpiryDate)
            .ThenBy(d => d.DocumentType)
            .Select(d => MapDocumentToResponse(d))
            .ToListAsync();

        // Mappers
        private static FarmerResponse MapToResponse(FarmerDetail f) => new()
        {
            Id = f.Id,
            FarmerNo = f.FarmerNo,
            NationalIdNo = f.NationalIdNo,
            PassportNo = f.PassportNo,
            FirstName = f.FirstName,
            MiddleName = f.MiddleName,
            LastName = f.LastName,
            Address = f.Address,
            PhoneNumber = f.PhoneNumber,
            AlternatePhoneNumber = f.AlternatePhoneNumber,
            EmailAddress = f.EmailAddress,
            FarmerTypeId = f.FarmerTypeId,
            FarmerTypeName = f.FarmerType?.Name,
            GenderId = f.GenderId,
            GenderName = f.Gender?.Name,
            CountryId = f.CountryId,
            CountryName = f.Country?.Name,
            UnitOfMeasurementId = f.UnitOfMeasurementId,
            RegistrationDate = f.RegistrationDate,
            IsVerified = f.IsVerified,
            IsActive = f.IsActive,
            CreatedOn = f.CreatedOn,
            ModifiedOn = f.ModifiedOn
        };

        private static FarmerDetailResponse MapToDetailResponse(FarmerDetail f) => new()
        {
            Id = f.Id,
            FarmerNo = f.FarmerNo,
            NationalIdNo = f.NationalIdNo,
            PassportNo = f.PassportNo,
            FirstName = f.FirstName,
            MiddleName = f.MiddleName,
            LastName = f.LastName,
            Address = f.Address,
            PhoneNumber = f.PhoneNumber,
            AlternatePhoneNumber = f.AlternatePhoneNumber,
            EmailAddress = f.EmailAddress,
            FarmerTypeId = f.FarmerTypeId,
            FarmerTypeName = f.FarmerType?.Name,
            GenderId = f.GenderId,
            GenderName = f.Gender?.Name,
            CountryId = f.CountryId,
            CountryName = f.Country?.Name,
            UnitOfMeasurementId = f.UnitOfMeasurementId,
            RegistrationDate = f.RegistrationDate,
            IsVerified = f.IsVerified,
            IsActive = f.IsActive,
            CreatedOn = f.CreatedOn,
            ModifiedOn = f.ModifiedOn,
            Contacts = new List<FarmerContactResponse>(),
            BankAccounts = new List<FarmerBankAccountResponse>(),
            Documents = new List<FarmerDocumentResponse>()
        };

        private static FarmerContactResponse MapContactToResponse(FarmerContact c) => new()
        {
            Id = c.Id,
            FarmerId = c.FarmerId,
            ContactName = c.ContactName,
            Relationship = c.Relationship,
            EmailAddress = c.EmailAddress,
            PhoneNumber = c.PhoneNumber,
            MobileNumber = c.MobileNumber,
            IsPrimaryContact = c.IsPrimaryContact
        };

        private static FarmerBankAccountResponse MapBankAccountToResponse(FarmerBankAccount b) => new()
        {
            Id = b.Id,
            FarmerId = b.FarmerId,
            BankName = b.BankName,
            BranchName = b.BranchName,
            AccountName = b.AccountName,
            AccountNumber = b.AccountNumber,
            SwiftCode = b.SwiftCode,
            IFSCCode = b.IFSCCode,
            AccountType = b.AccountType,
            IsPrimaryAccount = b.IsPrimaryAccount
        };

        private static FarmerDocumentResponse MapDocumentToResponse(FarmerDocument d) => new()
        {
            Id = d.Id,
            FarmerId = d.FarmerId,
            DocumentType = d.DocumentType,
            DocumentNumber = d.DocumentNumber,
            IssueDate = d.IssueDate,
            ExpiryDate = d.ExpiryDate,
            IsActive = d.IsActive,
            AttachmentId = d.AttachmentId
        };
    }
}
